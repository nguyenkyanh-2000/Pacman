using System.Drawing;

namespace Pacman;

public class ClydeStrategy : IGhostStrategy
{
    // When on chase mode, Claude will target Pacman if the (Manhattan) distance between them is greater than 8 cells
    // Otherwise he will target the bottom left corner of the maze (Scatter mode)
    public Point GetChaseTargetPosition()
    {
        Point pacmanPosition = new Point(PlayGameState.Pacman.X, PlayGameState.Pacman.Y);
        Point clydePosition = new Point(PlayGameState.Clyde.X, PlayGameState.Clyde.Y);
        if (Utils.ManhattanDistanceBetween(clydePosition, pacmanPosition) > 8)
        {
            return pacmanPosition;
        }
        return GetScatterTargetPosition();
    }

    // When on scatter mode, Claude will target the bottom left 
    public Point GetScatterTargetPosition()
    {
        return new Point(ProgramConfig.ScreenWidth, 0);
    }
}