using System.Numerics;

namespace Pacman;

public class InkyFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        // Inky is smaller to help with the movement
        return new Inky(x, y, ProgramConfig.MapCellSize - 2, new Vector2(0, 0), Inky.InkySprite);
    }
}