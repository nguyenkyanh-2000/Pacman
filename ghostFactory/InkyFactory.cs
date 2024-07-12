using System.Numerics;

namespace Pacman;

public class InkyFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        return new Inky(x, y, ProgramConfig.MapCellSize, new Vector2(0, 0), Inky.InkySprite);
    }
}