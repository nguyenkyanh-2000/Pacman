using System.Drawing;
using System.Numerics;

namespace Pacman;

public class EatenMode: GhostState
{
    public EatenMode(Ghost ghost) : base(ghost)
    {
    }
    
    
    public override Point GetTargetPosition()
    {
        return Ghost.RestingPosition;
    }

    public override void ComputeNextMoveDirection()
    {
        
        Point targetPosition = GetTargetPosition();
        Point currentPosition = new Point(Ghost.X, Ghost.Y);
        
        Vector2 currentVelocity = Ghost.Velocity;
        Vector2 nextVelocity = Ghost.Velocity;
    
        Vector2 currentDirection = Vector2.Normalize(currentVelocity);
        Vector2 oppositeDirection = new Vector2(-currentDirection.X, -currentDirection.Y);
    
        List<Vector2> possibleDirections = new List<Vector2>
        {
            new Vector2(0, -1),  // Up
            new Vector2(0, 1),  // Down
            new Vector2(-1, 0), // Left
            new Vector2(1, 0),  // Right
           
        };
    
        // Find the direction that matches the oppositeDirection and remove it from the list
        possibleDirections.Remove(possibleDirections.Find(direction => direction.Equals(oppositeDirection)));

        int minDistance = int.MaxValue;
        
        possibleDirections.ForEach((direction) =>
        {
            // Check if a possible direction will hit a wall in the future
            Vector2 tempVelocity = 2 * direction * ProgramConfig.GhostSpeed;
            Ghost.Velocity = tempVelocity;
            Wall? futureHitEntity = Ghost.CollisionDetector?.CollideWithWall(Ghost);
            Ghost.Velocity = currentVelocity;
            
            if (futureHitEntity is not null)
            {
                return;
            }
            
            Point nextPosition = new Point(currentPosition.X + (int) tempVelocity.X, currentPosition.Y + (int) tempVelocity.Y);
            int distance = Utils.DistanceBetween(nextPosition, targetPosition);
    
            if (minDistance > distance)
            {
                minDistance = distance;
                nextVelocity = tempVelocity;
            }
            
            // If the ghost has no possible directions to move, it will move in the opposite direction
            if (minDistance == int.MaxValue)
            {
                nextVelocity = oppositeDirection * ProgramConfig.GhostSpeed;   
            }
        });
        
        Ghost.Velocity = nextVelocity;
    }
}