using System.Numerics;

namespace Pacman;

public class BlinkyFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        // Blinky is smaller to help with the movement
        return new Blinky(x, y, ProgramConfig.MapCellSize - 2, new Vector2(0, 0), Blinky.BlinkySprite);
    }
}