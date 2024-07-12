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

    // public virtual void ComputeNextMoveDirection()
    // {
    //     Point targetPosition = GetTargetPosition();
    //     Point currentPosition = new Point(Ghost.X, Ghost.Y);
    //
    //     List<Point> paths  = Bfs.getPath( currentPosition,  targetPosition);
    //     
    //     if (paths.Count > 1)
    //     {
    //         Point nextPosition = paths[1];
    //         Vector2 nextVelocity = new Vector2(nextPosition.X - currentPosition.X, nextPosition.Y - currentPosition.Y);
    //         Ghost.Velocity = nextVelocity * ProgramConfig.GhostSpeed;
    //     }
    // }
    
    public virtual void ComputeNextMoveDirection()
    {
        Point targetPosition = GetTargetPosition();
        Point currentPosition = new Point(Ghost.X, Ghost.Y);
        
        Vector2 currentVelocity = Ghost.Velocity;
        Vector2 nextVelocity = new Vector2(0, 0);
    
        Vector2 currentDirection = Vector2.Normalize(currentVelocity);
        Vector2 oppositeDirection = new Vector2(-currentDirection.X, -currentDirection.Y);
    
        List<Vector2> possibleDirections = new List<Vector2>
        {
            new Vector2(0, -1),  // Up
            new Vector2(-1, 0), // Left
            new Vector2(0, 1),  // Down
            new Vector2(1, 0),  // Right
           
        };
        
        List<Vector2> exitDirections = new List<Vector2>();
    
        // Find the direction that matches the oppositeDirection and remove it from the list
        possibleDirections.Remove(possibleDirections.Find(direction => direction.Equals(oppositeDirection)));
        
        int minDistance = int.MaxValue;
        
        possibleDirections.ForEach((direction) =>
        {
            // Check if a possible direction will hit a wall in the future
            Vector2 tempVelocity = direction * ProgramConfig.GhostSpeed;
            Ghost.Velocity = tempVelocity;
            Entity? futureHitEntity = Ghost.CollisionDetector?.CollideWithWall(Ghost);
            Ghost.Velocity = currentVelocity;
    
            Console.WriteLine(Ghost + " will hit " + futureHitEntity?.GetType().Name + " if I go " + direction + " direction");
            
            if (futureHitEntity is not null)
            {
                return;
            }
            
            Console.WriteLine("Direction " + direction + " is possible");
            Point nextPosition = new Point(currentPosition.X + (int) tempVelocity.X, currentPosition.Y + (int) tempVelocity.Y);
            int distance = Utils.DistanceBetween(nextPosition, targetPosition);
    
            if (distance <= minDistance)
            {
                minDistance = distance;
                nextVelocity = tempVelocity;
            }
            
            exitDirections.Add(direction);
        });
        
        Ghost.Velocity = nextVelocity;
        
        if (exitDirections.Count == 0)
        {
            Ghost.Velocity = oppositeDirection * ProgramConfig.GhostSpeed;
        }
    }
}