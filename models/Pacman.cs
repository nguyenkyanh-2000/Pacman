using System.Numerics;
using SplashKitSDK;
using static Pacman.ProgramConfig;

namespace Pacman;
public class Pacman: MovingEntity, ISubject
{
    public CollisionDetector? CollisionDetector { set; get; }
    public List<IObserver> MyObservers { get; set; } = []; 
    public Pacman(float x, float y, Sprite sprite)
        : base(x, y, ProgramConfig.MapCellSize, new Vector2(0, 0), sprite)
    {}
    
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
        Entity? collidedEntity = CollisionDetector?.CollidedWith(this);

        if (collidedEntity != null)
        {
            if (collidedEntity is Pellet)
            {
                collidedEntity.Destroy();
                NotifyObserversThatPelletEaten();
            }
            
            if (collidedEntity is PowerPellet)
            {
                collidedEntity.Destroy();
                NotifyObserversThatEnergizedPelletEaten();
            }
            
            if (collidedEntity is Wall)
            {
                Velocity *= this.CollisionTimeRatio(collidedEntity);
            }
        }
        
        

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

    public void NotifyObserversThatPelletEaten()
    {
       MyObservers.ForEach((observer) => observer.UpdateWhenPelletEaten());
    }

    public void NotifyObserversThatEnergizedPelletEaten()
    {
        MyObservers.ForEach((observer) => observer.UpdateWhenEnergizedPelletEaten());
    }

    public void NotifyObserversThatGhostCollided()
    {
         MyObservers.ForEach((observer) => observer.UpdateWhenGhostCollided());
    }
}