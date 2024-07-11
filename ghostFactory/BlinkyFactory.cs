using System.Numerics;

namespace Pacman;

public class BlinkyFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        return new Blinky(x, y, ProgramConfig.MapCellSize, new Vector2(0, 0), Blinky.BlinkySprite);
    }
}