using System.Numerics;
using Pacman.ghostStrategies;
using SplashKitSDK;

namespace Pacman;

public class Inky: Ghost
{
    private static readonly Bitmap InkyBitmap = SplashKit.LoadBitmap("Inky", "inky.png");
    private static readonly AnimationScript InkyMovingScript = new AnimationScript("InkyMovingScript", "ghost.txt");
    public static readonly Sprite InkySprite = new Sprite("InkySprite", InkyBitmap, InkyMovingScript);
   
    
    public Inky(float x, float y, float size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, InkySprite)
    {
        InkyBitmap.SetCellDetails(InkySprite.Width/8, InkySprite.Height, 8, 1, 8 );
        Strategy = new BlinkyStrategy();
    }
}