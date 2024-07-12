using System.Drawing;
using System.Numerics;

namespace Pacman;

public class CollisionDetector
{
    private PlayGameState _playGameState;
    
    public CollisionDetector(PlayGameState playGameState)
    {
        _playGameState = playGameState;
    }

    /**
     *  Check if the entity collided with any other entity in the game
     */
    public Entity? CollidedWith(MovingEntity entity)
    {
        RectangleF entityFutureCollisionBox = entity.GetSweptBroadPhaseBox();
        foreach (Entity other in _playGameState.Entities)
        {
            if (entity == other) continue;
            
            if (entityFutureCollisionBox.IntersectsWith(other.CollisionBox()))
            {
                return other;
            }
        }

        return null;
    }
    public Wall? CollideWithWall(MovingEntity entity)
    {
        RectangleF entityFutureCollisionBox = entity.GetSweptBroadPhaseBox();
        
        foreach (Wall wall in _playGameState.Walls)
        {
            if (entityFutureCollisionBox.IntersectsWith(wall.CollisionBox()))
            {
                return wall;
            }
        }

        return null;
    }
}