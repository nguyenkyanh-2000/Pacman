using SplashKitSDK;

namespace Pacman;

public class PowerPellet: StaticEntity
{
    public PowerPellet(float x, float y, float size) : base(x, y, size)
    {
    }

    public PowerPellet(float x, float y, float size, Sprite sprite) : base(x, y, size, sprite)
    {
    }
    
    public override void Draw()
    {
        SplashKit.FillCircle(Color.Orange, X + ProgramConfig.MapCellSize/2.0f, Y + ProgramConfig.MapCellSize/2.0f, Size/2.0f);
    }
}