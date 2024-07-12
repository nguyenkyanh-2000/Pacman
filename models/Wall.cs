using SplashKitSDK;

namespace Pacman;

public class Wall: StaticEntity
{
    public Wall(int x, int y, int size) : base(x, y, size)
    {
    }

    public override void Draw()
    {
        SplashKit.FillRectangle(Color.Blue, X, Y, ProgramConfig.MapCellSize, ProgramConfig.MapCellSize);
    }
}