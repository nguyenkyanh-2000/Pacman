using System.Drawing;

namespace Pacman;

public abstract class GhostState
{
    public Ghost Ghost;
    
    public GhostState(Ghost ghost)
    {
        this.Ghost = ghost;
    }
    
    public void PowerPelletEaten(){}
    public void TimerModeOver(){}
    public void TimerFrightenedOver(){}
    public void Eaten(){}
    public void OutsideHouse(){}
    public void InsideHouse(){}
    
    public PointF GetTargetPosition()
    {
        return new PointF(0, 0);
    }

    public void ComputeNextMoveDirection()
    {
    }
}