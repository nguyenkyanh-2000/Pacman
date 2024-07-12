using SplashKitSDK;

namespace Pacman;

public class Pellet: StaticEntity
{
    public Pellet(int x, int y, int size) : base(x, y, size)
    {
    }

    public Pellet(int x, int y, int size, Sprite sprite) : base(x, y, size, sprite)
    {
    }

    public override void Draw()
    {
        SplashKit.FillCircle(Color.Gray, X + ProgramConfig.MapCellSize/2.0f, Y + ProgramConfig.MapCellSize/2.0f, Size);
    }
}