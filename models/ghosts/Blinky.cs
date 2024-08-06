using System.Numerics;
using SplashKitSDK;

namespace Pacman;

public class Blinky: Ghost
{
    private static readonly Bitmap BlinkyBitmap = SplashKit.LoadBitmap("Blinky", Utils.BuildPath("resources/images/blinky.png"));
    private static readonly AnimationScript BlinkyMovingScript = new AnimationScript("BlinkyMovingScript", "ghost.txt");
    public static readonly Sprite BlinkySprite = new Sprite("BlinkySprite", BlinkyBitmap, BlinkyMovingScript);
   
    
    public Blinky(int x, int y, int size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, BlinkySprite)
    {
        BlinkyBitmap.SetCellDetails(ProgramConfig.MapCellSize, ProgramConfig.MapCellSize, 8, 1, 8 );
        Strategy = new BlinkyStrategy();
    }
}