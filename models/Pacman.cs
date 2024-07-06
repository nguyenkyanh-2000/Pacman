using System.Numerics;
using SplashKitSDK;
using static Pacman.ProgramConfig;

namespace Pacman;
public class Pacman: MovingEntity
{
    public CollisionDetector? CollisionDetector { set; get; }
    public Pacman(float x, float y, Sprite sprite)
        : base(x, y, ProgramConfig.MapCellSize, new Vector2(0, 0), sprite)
    {
        // sprite.X = x + sprite.Width / 2.0f;
        // sprite.Y = y + sprite.Height / 2.0f;
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
        Entity? collidedEntity = CollisionDetector?.CollidedWith(this);

        if (collidedEntity != null)
        {
            if (collidedEntity is Pellet)
            {
                collidedEntity.Destroy();
            }
            
            if (collidedEntity is EnergizedPellet)
            {
                collidedEntity.Destroy();
            }
            
            if (collidedEntity is Wall)
            {
                Velocity *= this.CollisionTimeRatio(collidedEntity);
            }
        }
        
        

        base.Update();
    }
}