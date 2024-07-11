using System.Numerics;
using Pacman.ghostStrategies;
using SplashKitSDK;

namespace Pacman;

public class Clyde: Ghost
{
    private static readonly Bitmap ClydeBitmap = SplashKit.LoadBitmap("Clyde", "clyde.png");
    private static readonly AnimationScript ClydeMovingScript = new AnimationScript("ClydeMovingScript", "ghost.txt");
    public static readonly Sprite ClydeSprite = new Sprite("ClydeSprite", ClydeBitmap, ClydeMovingScript);
   
    
    public Clyde(float x, float y, float size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, ClydeSprite)
    {
        ClydeBitmap.SetCellDetails(ClydeSprite.Width/8, ClydeSprite.Height, 8, 1, 8 );
        Strategy = new BlinkyStrategy();
    }
}