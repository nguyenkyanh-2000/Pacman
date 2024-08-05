using SplashKitSDK;

namespace Pacman;

public class PowerPellet: Pellet
{
    public PowerPellet(int x, int y, int size) : base(x, y, size)
    {
    }

    public PowerPellet(int x, int y, int size, Sprite sprite) : base(x, y, size, sprite)
    {
    }
    
    public override void Draw()
    {
        SplashKit.FillCircle(Color.Orange, X + ProgramConfig.MapCellSize/2.0f, Y + ProgramConfig.MapCellSize/2.0f, Size/2.0f);
    }
}