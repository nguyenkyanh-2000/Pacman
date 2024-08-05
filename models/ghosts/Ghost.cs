using System.Drawing;
using System.Numerics;
using SplashKitSDK;

namespace Pacman;

public class Ghost: MovingEntity
{
    
    public Point RestingPosition { get; set; }
    public GhostState State { get; private set; }
    private Sprite OriginalSprite { get; set; }
    private Sprite FrightenedSprite { get; set; } = null!;
    
    protected readonly GhostState ChaseMode; 
    protected readonly GhostState FrightenedMode;
    protected readonly GhostState EatenMode;
    protected readonly GhostState ScatterMode;

    protected int ScatterTimer { get; set; } = 0;
    protected int FrightenedTimer { get; set; } = 0;
    protected bool IsChasing { get; set; } = true;

    public IGhostStrategy Strategy { get; set; } = null!;
    
    public CollisionDetector? CollisionDetector { set; get; }
    
    
    public Ghost(int x, int y, int size, Vector2 velocity, Sprite sprite) : base(x, y, size, velocity, sprite)
    
    {
        ChaseMode = new ChaseMode(this);
        FrightenedMode = new FrightenedMode(this);
        EatenMode = new EatenMode(this);
        ScatterMode = new ScatterMode(this);
        
        State = ChaseMode;
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
        
        // If the ghost is in eaten mode, update the animation and change the state to chase mode when the ghost reaches
        // the resting position
        if (State == EatenMode)
        {
            // Moving animation for the ghost
            if (Velocity.X > 0)
            {
                Sprite?.StartAnimation("EatenGhostRight");
            }
        
            if (Velocity.X < 0)
            {
                Sprite?.StartAnimation("EatenGhostLeft");
            }
        
            if (Velocity.Y > 0)
            {
                Sprite?.StartAnimation("EatenGhostDown");
            }
        
            if (Velocity.Y < 0)
            {
                Sprite?.StartAnimation("EatenGhostUp");
            }
            
            Entity restingPosition = new StaticEntity(RestingPosition.X, RestingPosition.Y, 20);
            if (this.IntersectsWith(restingPosition))
            {
                ToChaseMode();
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
        
        // Reverse the direction of the ghost. The ghost will move at 0.8 times the speed
        Velocity = -Velocity;
        
        // Set the state to frightened mode
        State = FrightenedMode;
        FrightenedTimer = 0;
    }
    
    public void ToEatenMode()
    {
        State = EatenMode;
        
        // Load the eaten ghost sprite based on the bitmap and animation script
        AnimationScript eatenGhostMovingScript =
            new AnimationScript("EatenGhostMovingScript", "ghost_eaten.txt");
        Bitmap eatenGhostBitmap = SplashKit.LoadBitmap("EatenGhost", "ghost_eaten.png");
        Sprite eatenGhostSprite =
            new Sprite("EatenGhostSprite", eatenGhostBitmap, eatenGhostMovingScript);
        eatenGhostBitmap.SetCellDetails(20, eatenGhostSprite.Height, 4, 1, 4);

        Sprite = eatenGhostSprite;
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