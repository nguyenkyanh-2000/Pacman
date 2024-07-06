using SplashKitSDK;

namespace Pacman;

public class Wall: StaticEntity
{
    public Wall(float x, float y, float size) : base(x, y, size)
    {
    }

    public override void Draw()
    {
        // Fixed drawing size, but smaller collision box size of wall
        SplashKit.FillRectangle(Color.Black, X, Y, ProgramConfig.MapCellSize, ProgramConfig.MapCellSize);
    }
}