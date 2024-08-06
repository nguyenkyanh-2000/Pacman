using System.Numerics;
using SplashKitSDK;

namespace Pacman;

public class Clyde: Ghost
{
    private static readonly Bitmap ClydeBitmap = SplashKit.LoadBitmap("Clyde", Utils.BuildPath("resources/images/clyde.png"));
    private static readonly AnimationScript ClydeMovingScript = new AnimationScript("ClydeMovingScript", "ghost.txt");
    public static readonly Sprite ClydeSprite = new Sprite("ClydeSprite", ClydeBitmap, ClydeMovingScript);
   
    
    public Clyde(int x, int y, int size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, ClydeSprite)
    {
        ClydeBitmap.SetCellDetails(ProgramConfig.MapCellSize, ProgramConfig.MapCellSize, 8, 1, 8 );
        Strategy = new ClydeStrategy();
    }
}