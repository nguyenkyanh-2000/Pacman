using System.Numerics;
using Pacman;

namespace Pacman;

using System.Drawing;

public class PinkyStrategy: IGhostStrategy
{
    // When on chase mode, Pinky will try to ambush Pacman by targeting 4 cells ahead of Pacman
    public Point GetChaseTargetPosition()
    {
        Vector2 pacmanDirection = Vector2.Normalize(PlayGameState.Pacman.Velocity);
        return new Point((int)(PlayGameState.Pacman.X + 4*pacmanDirection.X), (int)(PlayGameState.Pacman.Y+ 4*pacmanDirection.Y));
    }

    // When on scatter mode, Pinky will target the top left corner of the maze
    public Point GetScatterTargetPosition()
    {
        return new Point(0, 0);
    }
}