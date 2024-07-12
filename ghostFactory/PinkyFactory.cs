using System.Numerics;

namespace Pacman;

public class PinkyFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        return new Pinky(x, y, ProgramConfig.MapCellSize, new Vector2(0, 0), Pinky.PinkySprite);
    }
}