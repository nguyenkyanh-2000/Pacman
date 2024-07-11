using System.Drawing;

namespace Pacman.ghostStrategies;

public class BlinkyStrategy: IGhostStrategy
{
    // When on chase mode, Blinky will target the position of Pacman
    public PointF GetChaseTargetPosition()
    {
        return new PointF(PlayGameState.Pacman.X, PlayGameState.Pacman.Y);
    }

    // When on scatter mode, Blinky will target the top right corner of the maze
    public PointF GetScatterTargetPosition()
    {
        return new PointF(ProgramConfig.ScreenWidth, 0);
    }
}