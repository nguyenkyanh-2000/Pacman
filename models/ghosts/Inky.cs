using System.Numerics;
using SplashKitSDK;

namespace Pacman;

public class Inky: Ghost
{
    private static readonly Bitmap InkyBitmap = SplashKit.LoadBitmap("Inky", "inky.png");
    private static readonly AnimationScript InkyMovingScript = new AnimationScript("InkyMovingScript", "ghost.txt");
    public static readonly Sprite InkySprite = new Sprite("InkySprite", InkyBitmap, InkyMovingScript);
   
    
    public Inky(int x, int y, int size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, InkySprite)
    {
        InkyBitmap.SetCellDetails(ProgramConfig.MapCellSize, ProgramConfig.MapCellSize, 8, 1, 8 );
        Strategy = new InkyStrategy();
    }
}