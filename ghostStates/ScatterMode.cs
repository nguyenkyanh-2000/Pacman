using System.Drawing;

namespace Pacman;

public class ScatterMode: GhostState
{
    public ScatterMode(Ghost ghost) : base(ghost)
    {
    }
    
    public override void PowerPelletEaten()
    {
        this.Ghost.ToFrightenedMode();
    }
    
    public override void TimerModeOver()
    {
        this.Ghost.ToChaseMode();
    }

    public override Point GetTargetPosition()
    {
        return Ghost.Strategy.GetScatterTargetPosition();
    }
}

