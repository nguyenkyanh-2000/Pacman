using System.Numerics;
using Pacman;

namespace Pacman;

using System.Drawing;

public class InkyStrategy : IGhostStrategy
{
    // When on chase mode, Inky will try to ambush Pacman based on Blinky's position and Pacman's direction
    public Point GetChaseTargetPosition()
    {
        Vector2 pacmanDirection = Vector2.Normalize(PlayGameState.Pacman.Velocity);
        Vector2 blinkyPosition = new Vector2(PlayGameState.Blinky.X, PlayGameState.Blinky.Y);
        Vector2 targetPosition = blinkyPosition + 4 * pacmanDirection;
        return new Point((int)targetPosition.X, (int)targetPosition.Y);
    }

    // When on scatter mode, Inky will target the bottom right corner of the maze
    public Point GetScatterTargetPosition()
    {
        return new Point(ProgramConfig.ScreenWidth, ProgramConfig.ScreenHeight);
    }
}