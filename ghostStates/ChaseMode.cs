using System.Drawing;

namespace Pacman;

public class ChaseMode: GhostState
{
    public ChaseMode(Ghost ghost) : base(ghost)
    {
    }
    
    
    public override void PowerPelletEaten()
    {
        this.Ghost.ToFrightenedMode();
    }
    
    public override void TimerModeOver()
    {
        this.Ghost.ToScatterMode();
    }
    
    
    // In this state, the target position depends on the ghost's strategy (type)
    public override Point GetTargetPosition()
    {
        return this.Ghost.Strategy.GetChaseTargetPosition();
    }
}