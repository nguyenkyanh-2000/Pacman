namespace Pacman;

public class FrightenedMode: GhostState
{
    public FrightenedMode(Ghost ghost) : base(ghost)
    {
    }

    public override void TimerFrightenedOver()
    {
        this.Ghost.ToChaseOrScatterMode();
    }
}