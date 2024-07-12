using System.Drawing;
using System.Numerics;
using SplashKitSDK;

namespace Pacman;

public abstract class MovingEntity: Entity
{
    public Vector2 Velocity { get; set; }

    protected MovingEntity(int x, int y, int size, Vector2 velocity, Sprite sprite)
        : base(x, y, size, sprite)
    {
        Velocity = velocity;
    }
    
    protected MovingEntity(int x, int y, int size, Vector2 velocity) 
        : base(x, y, size)
    {
        Velocity = velocity;
    }
    
    public void Move()
    {
      if (Velocity.Length() == 0) return;
      this.X += (int) Velocity.X;
      this.Y += (int) Velocity.Y;
    }
    
    public override void Update()
    {
        Move();
        base.Update();
    }
    
    // Get Swept Broad-phase AABB Rectangle
    public RectangleF GetSweptBroadPhaseBox()
    {
        int x = Velocity.X > 0 ? X : X + (int) Velocity.X;
        int y = Velocity.Y > 0 ? Y : Y + (int) Velocity.Y;
        int w = Velocity.X > 0 ? (int) Velocity.X + Size : Size - (int) Velocity.X;
        int h = Velocity.Y > 0 ? (int) Velocity.Y + Size : Size - (int) Velocity.Y;
        return new RectangleF(x, y, w, h);
    }
    
    // Sweep AABB collision detection. Work for both static and moving entities
    public float CollisionTimeRatio(Entity other)
    {

        // Top: Distance between the top of the moving entity and the bottom of the other entity
        // Bottom: Distance between the bottom of the moving entity and the top of the other entity
        // Left: Distance between the left of the moving entity and the right of the other entity
        // Right: Distance between the right of the moving entity and the left of the other entity
        int left = other.X - (this.X + this.Size);
        int right = (other.X + other.Size) - this.X;
        int top = other.Y - (this.Y + this.Size);
        int bottom = (other.Y + other.Size) - this.Y;


        int dxEntry, dyEntry;
        int dxExit, dyExit;

        // Calculate the distance between corresponding edges of the two entities
        if (this.Velocity.X > 0)
        {
            dxEntry = left;
            dxExit = right;
        }
        else
        {
            dxEntry = right;
            dxExit = left;
        }

        if (this.Velocity.Y > 0)
        {
            dyEntry = top;
            dyExit = bottom;
        }
        else
        {
            dyEntry = bottom;
            dyExit = top;
        }

        float txEntry, tyEntry;
        float txExit, tyExit;

        // If the moving object is not moving on the axis, set the time of collision and time of leaving to infinity
        if (this.Velocity.X == 0)
        {
            txEntry = float.NegativeInfinity;
            txExit = float.PositiveInfinity;
        }
        else
        {
            txEntry = dxEntry / this.Velocity.X;
            txExit = dxExit / this.Velocity.X;
        }

        if (this.Velocity.Y == 0)
        {
            tyEntry = float.NegativeInfinity;
            tyExit = float.PositiveInfinity;
        }
        else
        {
            tyEntry = dyEntry / this.Velocity.Y;
            tyExit = dyExit / this.Velocity.Y;
        }


        // The time of collision is the maximum of the time of collision on the x-axis and the time of collision on the y-axis
        // Collision occurs when both axis collide
        float entryTime = Math.Max(txEntry, tyEntry);

        // The time of leaving is the minimum of the time of leaving on the x-axis and the time of leaving on the y-axis
        // Leaving occurs when either axis leaves
        float exitTime = Math.Min(txExit, tyExit);

        // If the time of collision is greater than the time of leaving, there is no collision
        if (entryTime > exitTime || txEntry < 0 && tyEntry < 0 || txEntry > 1 || tyEntry > 1)
        {
            return 1.0f;
        }
        else
        {
            return entryTime;
        }
    }
    
}