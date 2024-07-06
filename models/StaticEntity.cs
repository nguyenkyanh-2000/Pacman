using SplashKitSDK;

namespace Pacman;

public class StaticEntity: Entity
{
    
    public StaticEntity(float x, float y, float size) : base(x, y, size)
    {
    }
    
    public StaticEntity(float x, float y, float size, Sprite sprite) : base(x, y, size, sprite)
    {
    }
    
}