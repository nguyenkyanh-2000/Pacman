using System.Numerics;

namespace Pacman;

public class ClydeFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        return new Clyde(x, y, ProgramConfig.MapCellSize, new Vector2(0, 0), Clyde.ClydeSprite);
    }
}