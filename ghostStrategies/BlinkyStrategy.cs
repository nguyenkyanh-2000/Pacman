using System.Drawing;

namespace Pacman;

public class BlinkyStrategy: IGhostStrategy
{
    // When on chase mode, Blinky will target the position of Pacman
    public Point GetChaseTargetPosition()
    {
        return new Point(PlayGameState.Pacman.X, PlayGameState.Pacman.Y);
    }

    // When on scatter mode, Blinky will target the top right corner of the maze
    public Point GetScatterTargetPosition()
    {
        return new Point(ProgramConfig.ScreenWidth, 0);
    }
}