using System.Drawing;
using System.Numerics;

namespace Pacman;

public abstract class GhostState
{
    public Ghost Ghost;
    
    public GhostState(Ghost ghost)
    {
        this.Ghost = ghost;
    }
    
    public virtual void PowerPelletEaten(){}
    public virtual void TimerModeOver(){}
    public virtual void TimerFrightenedOver(){}
    public virtual void Eaten(){}
    public virtual void OutsideHouse(){}
    public virtual void InsideHouse(){}
    
    public virtual Point GetTargetPosition()
    {
        return new Point(0, 0);
    }
    
    
    /**
     * Greedy algorithm to compute the next move direction of the ghost.
     * This method is used to compute the next move direction of the ghost.
     * The ghost will move in the direction that will get it closer to the target position.
     * If the ghost is about to hit a wall, it will change direction.
     * The ghost cannot move in the opposite direction of its current direction.
     * Priority of direction: Up > Down > Left > Right
     */
    
    public virtual void ComputeNextMoveDirection()
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
            Vector2 tempVelocity = direction * ProgramConfig.GhostSpeed;
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
        });
        
        Ghost.Velocity = nextVelocity;
    }
}