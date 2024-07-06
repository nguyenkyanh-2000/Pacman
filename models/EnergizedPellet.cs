using SplashKitSDK;

namespace Pacman;

public class EnergizedPellet: StaticEntity
{
    public EnergizedPellet(float x, float y, float size) : base(x, y, size)
    {
    }

    public EnergizedPellet(float x, float y, float size, Sprite sprite) : base(x, y, size, sprite)
    {
    }
    
    public override void Draw()
    {
        SplashKit.FillCircle(Color.Orange, X + ProgramConfig.MapCellSize/2.0f, Y + ProgramConfig.MapCellSize/2.0f, Size);
    }
}