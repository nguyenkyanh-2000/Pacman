using SplashKitSDK;

namespace Pacman;

public class Pellet: StaticEntity
{
    public Pellet(float x, float y, float size) : base(x, y, size)
    {
    }

    public Pellet(float x, float y, float size, Sprite sprite) : base(x, y, size, sprite)
    {
    }

    public override void Draw()
    {
        SplashKit.FillCircle(Color.Gray, X + ProgramConfig.MapCellSize/2.0f, Y + ProgramConfig.MapCellSize/2.0f, Size);
    }
}