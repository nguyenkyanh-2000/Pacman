using System.Numerics;
using Pacman.ghostStrategies;
using SplashKitSDK;

namespace Pacman;

public class Pinky: Ghost
{
    private static readonly Bitmap PinkyBitmap = SplashKit.LoadBitmap("Pinky", "pinky.png");
    private static readonly AnimationScript PinkyMovingScript = new AnimationScript("PinkyMovingScript", "ghost.txt");
    public static readonly Sprite PinkySprite = new Sprite("PinkySprite", PinkyBitmap, PinkyMovingScript);
   
    
    public Pinky(float x, float y, float size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, PinkySprite)
    {
        PinkyBitmap.SetCellDetails(PinkySprite.Width/8, PinkySprite.Height, 8, 1, 8 );
        Strategy = new BlinkyStrategy();
    }
}