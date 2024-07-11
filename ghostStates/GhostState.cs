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
    
    public virtual PointF GetTargetPosition()
    {
        return new PointF(0, 0);
    }

    public virtual void ComputeNextMoveDirection()
    {
        Vector2 newVelocity = new Vector2(0, 0);
        
        float minDistance = float.MaxValue;
        PointF ghostPosition = new PointF(Ghost.X, Ghost.Y);
        
        List<Vector2> possibleDirections =
        [
            new Vector2(0, -1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(-1, 0)
        ];
        
        // Ghosts can't go backward
        Vector2 oppositeDirection = new Vector2(-Ghost.Velocity.X, -Ghost.Velocity.Y);
        oppositeDirection = Vector2.Normalize(oppositeDirection);
        possibleDirections.Remove(oppositeDirection);
        
        foreach (Vector2 direction in possibleDirections)
        {
            PointF newPosition = new PointF(ghostPosition.X + direction.X, ghostPosition.Y + direction.Y);
            float distance = Utils.DistanceBetween(newPosition, this.GetTargetPosition());
            if (distance < minDistance)
            {
                minDistance = distance;
                newVelocity = direction * ProgramConfig.GhostSpeed;
            }
        }
        
        Ghost.Velocity = newVelocity;
        
    }
}