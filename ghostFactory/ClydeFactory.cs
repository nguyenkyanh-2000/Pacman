using System.Numerics;

namespace Pacman;

public class ClydeFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        // Clyde is smaller to help with the movement
        return new Clyde(x, y, ProgramConfig.MapCellSize - 2, new Vector2(0, 0), Clyde.ClydeSprite);
    }
}