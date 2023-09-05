using UnityEngine;

using Prototype.Gameplay.ActiveArea;

namespace Prototype.Gameplay.Obstacles
{
    public class ObstacleSquare : Obstacle
    {
        [SerializeField] private MovementInArea movementInArea;
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!movementInArea.IsActive)
                return;
            
            if (other.GetComponent<Area>())
                GameplayPool.Single.ReturnObstacle(PooledObjectType.Obstacle, movementInArea);
        }
    }
}
