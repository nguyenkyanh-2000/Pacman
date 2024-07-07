using System.Numerics;
using SplashKitSDK;

namespace Pacman;

public class Ghost: MovingEntity
{
    private GhostState State { get; }
    
    protected readonly GhostState ChaseMode; 
    protected readonly GhostState FrightenedMode;
    protected readonly GhostState HouseMode;
    protected readonly GhostState EatenMode;
    protected readonly GhostState ScatterMode;
    
    protected int ModeTimer { get; set; }
    protected int FrightenedTimer { get; set; }
    
    
    public Ghost(float x, float y, float size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, sprite)
    
    {
        
    }

    public Ghost(float x, float y, float size, Vector2 velocity) : base(x, y, size, velocity)
    {
    }
    
    
}