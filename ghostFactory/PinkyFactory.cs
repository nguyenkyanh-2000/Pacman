using System.Numerics;

namespace Pacman;

public class PinkyFactory: GhostFactory
{
    public override Ghost CreateGhost(int x, int y)
    {
        // Pinky is smaller to help with the movement
        return new Pinky(x, y, ProgramConfig.MapCellSize - 2, new Vector2(0, 0), Pinky.PinkySprite);
    }
}