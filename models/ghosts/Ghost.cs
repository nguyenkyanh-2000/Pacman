using System.Numerics;
using Pacman.ghostStrategies;
using SplashKitSDK;

namespace Pacman;

public class Ghost: MovingEntity
{
    
    
    private GhostState State { get; set; }
    private Sprite OriginalSprite { get; set; }
    private Sprite FrightenedSprite { get; set; } = null!;
    
    protected readonly GhostState ChaseMode; 
    protected readonly GhostState FrightenedMode;
    protected readonly GhostState HouseMode;
    protected readonly GhostState EatenMode;
    protected readonly GhostState ScatterMode;

    protected int ModeTimer { get; set; } = 0;
    protected int FrightenedTimer { get; set; } = 0;
    protected bool IsChasing { get; set; } = true;

    public IGhostStrategy Strategy { get; set; } = null!;
    
    public CollisionDetector? CollisionDetector { set; get; }
    
    public Ghost(float x, float y, float size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, sprite)
    
    {
        ChaseMode = new ChaseMode(this);
        FrightenedMode = new FrightenedMode(this);
        HouseMode = new HouseMode(this);
        EatenMode = new EatenMode(this);
        ScatterMode = new ScatterMode(this);
        
        State = HouseMode;
        
        OriginalSprite = sprite;
    }

    public override void Update()
    {
        
        // If the ghost is in frightened mode, increment the timer.
        // If the timer is greater than 8 seconds and less than 10 seconds, change the sprite every 10 frames to warn
        // If the timer is greater than 10 seconds, change the state to chase or scatter mode
        if (State == FrightenedMode)
        {
            FrightenedTimer++;
            
            if (FrightenedTimer >= 8 * 60 && FrightenedTimer < 10 * 60 && FrightenedTimer % 10 == 0)
            {
                Sprite = OriginalSprite;
            }
            else
            {
                Sprite = FrightenedSprite;
            }
            
            
            if (FrightenedTimer >= 60 * 10)
            {
                State.TimerFrightenedOver();
            }
        }

        State.ComputeNextMoveDirection();
        base.Update();
        
    }
    

    // Methods to transition between states
    public void ToChaseMode()
    {
        State = ChaseMode;
        Sprite = OriginalSprite;
        Sprite.StartAnimation(0);
    }

    // NOTE: Animation script is not working properly. As such set the cell details to fixed values = 20
    public void ToFrightenedMode()
    {
        
        // Load the frightened ghost sprite based on the bitmap and animation script
        AnimationScript frightenedGhostMovingScript =
            new AnimationScript("FrightenedGhostMovingScript", "ghost_frightened.txt");
        Bitmap frightenedGhostBitmap = SplashKit.LoadBitmap("FrightenedGhost", "ghost_frightened.png");
        Sprite frightenedGhostSprite =
            new Sprite("FrightenedGhostSprite", frightenedGhostBitmap, frightenedGhostMovingScript);
        frightenedGhostBitmap.SetCellDetails(20, frightenedGhostSprite.Height, 2, 1, 2);

        
        // Set the sprite to the frightened ghost sprite
        FrightenedSprite = frightenedGhostSprite;
        Sprite = FrightenedSprite;
        Sprite.StartAnimation(0);
        
        // Set the state to frightened mode
        State = FrightenedMode;
        FrightenedTimer = 0;
    }

    public void ToHouseMode()
    {
        State = HouseMode;
    }
    
    public void ToEatenMode()
    {
        State = EatenMode;
    }
    
    public void ToScatterMode()
    {
        State = ScatterMode;
        
        Sprite = OriginalSprite;
        Sprite.StartAnimation(0);
    }
    
    public void ToChaseOrScatterMode()
    {
        if (IsChasing)
        {
            ToChaseMode();
        }
        else
        {
            ToScatterMode();
        }
    }
}