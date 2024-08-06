using System.Numerics;
using SplashKitSDK;

namespace Pacman;

public class Pinky: Ghost
{
    private static readonly Bitmap PinkyBitmap = SplashKit.LoadBitmap("Pinky", Utils.BuildPath("resources/images/pinky.png"));
    private static readonly AnimationScript PinkyMovingScript = new AnimationScript("PinkyMovingScript", "ghost.txt");
    public static readonly Sprite PinkySprite = new Sprite("PinkySprite", PinkyBitmap, PinkyMovingScript);
   
    
    public Pinky(int x, int y, int size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, PinkySprite)
    {
        PinkyBitmap.SetCellDetails(ProgramConfig.MapCellSize, ProgramConfig.MapCellSize, 8, 1, 8 );
        Strategy = new PinkyStrategy();
    }
}