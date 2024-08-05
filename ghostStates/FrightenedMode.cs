using System.Drawing;
using System.Numerics;

namespace Pacman;

public class FrightenedMode: GhostState
{
    public FrightenedMode(Ghost ghost) : base(ghost)
    {
    }

    public override void Eaten()
    {
        Ghost.ToEatenMode();
    }

    public override void ComputeNextMoveDirection()
    {
        Vector2 currentVelocity = Ghost.Velocity;

        Vector2 currentDirection = Vector2.Normalize(currentVelocity);
        Vector2 oppositeDirection = new Vector2(-currentDirection.X, -currentDirection.Y);
        
        List<Vector2> movableDirections = new List<Vector2>();
        List<Vector2> possibleDirections = new List<Vector2>
        {
            new Vector2(0, -1),  // Up
            new Vector2(0, 1),  // Down
            new Vector2(-1, 0), // Left
            new Vector2(1, 0),  // Right
        };
        
        //  Find the direction that matches the oppositeDirection and remove it from the list
        possibleDirections.Remove(possibleDirections.Find(direction => direction.Equals(oppositeDirection)));
        
        possibleDirections.ForEach((direction) =>
        {
            // Check if a possible direction will hit a wall in the future
            Vector2 tempVelocity = direction * ProgramConfig.GhostSpeed;
            Ghost.Velocity = tempVelocity;
            Wall? futureHitEntity = Ghost.CollisionDetector?.CollideWithWall(Ghost);
            Ghost.Velocity = currentVelocity;
            
            if (futureHitEntity is not null)
            {
                return;
            }
            
            movableDirections.Add(direction);;
            
        });

        // If there are no movable directions, add the opposite direction
        if (movableDirections.Count == 0)
        {
            movableDirections.Add(oppositeDirection);
        }

        Random random = new Random();
        int randomIndex = random.Next(movableDirections.Count);
        Vector2 nextVelocity = movableDirections[randomIndex] * ProgramConfig.GhostSpeed;
        Ghost.Velocity = nextVelocity;
    }

    public override void TimerFrightenedOver()
    {
        this.Ghost.ToChaseOrScatterMode();
    }
}