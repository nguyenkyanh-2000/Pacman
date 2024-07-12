using SplashKitSDK;

namespace Pacman;

public class StaticEntity: Entity
{
    
    public StaticEntity(int x, int y, int size) : base(x, y, size)
    {
    }
    
    public StaticEntity(int x, int y, int size, Sprite sprite) : base(x, y, size, sprite)
    {
    }
    
}