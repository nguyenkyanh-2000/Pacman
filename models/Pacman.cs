using System.Numerics;
using SplashKitSDK;
using static Pacman.ProgramConfig;

namespace Pacman;
public class Pacman: MovingEntity, ISubject
{
    // Loading the Sprite for Pacman
    private static readonly Bitmap PacmanBitmap = SplashKit.LoadBitmap("Pacman", "pacman.png");
    private static readonly AnimationScript PacmanMovingScript = new AnimationScript("PacmanMovingScript", "pacman.txt");
    private static readonly Sprite PacmanSprite = new Sprite("PacmanSprite", PacmanBitmap, PacmanMovingScript);
    
    
    public CollisionDetector? CollisionDetector { set; get; }
    public List<IObserver> MyObservers { get; set; } = [];

    public Pacman(int x, int y)
         // Pacman is smaller to help with the movement
        : base(x, y, ProgramConfig.MapCellSize - 2, new Vector2(0, 0), PacmanSprite)
    {
        PacmanBitmap.SetCellDetails(MapCellSize,MapCellSize, 16, 1, 16 );
    }
    
    public void HandleInput()
    {
        
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Velocity = new Vector2(0, -PacmanSpeed);
            Sprite?.StartAnimation("PacmanUp");
        }
        else if (SplashKit.KeyDown(KeyCode.DownKey))
        {
           Velocity = new Vector2(0, PacmanSpeed);
            Sprite?.StartAnimation("PacmanDown");
        }
        else if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
           Velocity = new Vector2(-PacmanSpeed, 0);
           Sprite?.StartAnimation("PacmanLeft");
        }
        else if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            Velocity = new Vector2(PacmanSpeed, 0);
            Sprite?.StartAnimation("PacmanRight");
        }
    }
    
    public override void Update()
    {
        List<Entity> collidedEntities = CollisionDetector?.CollidedWith(this) ?? [];
        
        collidedEntities.ForEach((entity) =>
        {
            if (entity is Pellet pellet)
            {
                NotifyObserversThatPelletEaten(pellet);
            }
            
            if (entity is PowerPellet powerPellet)
            {
                NotifyObserversThatPowerPelletEaten(powerPellet);
            }
            
            if (entity is Wall)
            {
                Velocity *= this.CollisionTimeRatio(entity);
            }
            
            if (entity is Ghost ghost)
            {
                NotifyObserversThatGhostCollided(ghost);
            }
        });
        

        base.Update();
    }

    public void AttachObserver(IObserver observer)
    {
        MyObservers.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        MyObservers.Remove(observer);
    }

    public void NotifyObserversThatPelletEaten(Pellet pellet)
    {
       MyObservers.ForEach((observer) => observer.UpdateWhenPelletEaten(pellet));
    }

    public void NotifyObserversThatPowerPelletEaten(PowerPellet powerPellet)
    {
        MyObservers.ForEach((observer) => observer.UpdateWhenPowerPelletEaten(powerPellet));
    }

    public void NotifyObserversThatGhostCollided(Ghost ghost)
    {
         MyObservers.ForEach((observer) => observer.UpdateWhenGhostCollided(ghost));
    }
}