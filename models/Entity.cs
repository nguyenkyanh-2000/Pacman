using System.Drawing;
using SplashKitSDK;


namespace Pacman;

public abstract class Entity
{
    public float Size { get; }
    private PointF _position;
    public Sprite? Sprite { get; set; }
    public bool IsDestroyed { get; private set; } = false;

    public Entity(float x, float y, float size)
    {
        _position.X = x;
        _position.Y = y;
        Size = size;
    }
    
    public Entity(float x, float y, float size, Sprite sprite)
    {
        _position.X = x;
        _position.Y = y;
        Size = size;
        Sprite = sprite;
        Sprite.X = x;
        Sprite.Y = y;
        Sprite.StartAnimation(0);
    }

    public void Destroy()
    {
        _position = new PointF(-9999, -9999);
        IsDestroyed = true;
        if (Sprite != null) SplashKit.FreeSprite(Sprite);
    }

    public virtual void Update()
    {
        Sprite?.UpdateAnimation();
    }

    public virtual void Draw()
    {
        Sprite?.Draw();
    }

    public RectangleF CollisionBox()
    {
        return new RectangleF(X, Y, Size,  Size);
    }

    public virtual bool IntersectsWith(Entity other)
    {
        return CollisionBox().IntersectsWith(other.CollisionBox());
    }

    public float X
    {
        get => _position.X;
        set
        {
            _position.X = value;
            if (Sprite != null) SplashKit.SpriteSetX(Sprite, value);
        }
    }

    public float Y
    {
        get => _position.Y;
        set
        {
            _position.Y = value;
            if (Sprite != null) SplashKit.SpriteSetY(Sprite, value);
        }
    }
    
}