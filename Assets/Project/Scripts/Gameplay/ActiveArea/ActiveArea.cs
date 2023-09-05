using UnityEngine;

using Prototype.Gameplay.Obstacles;

namespace Prototype.Gameplay.ActiveArea
{
    public class ActiveArea : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            var obstacle = other.GetComponent<ObstacleSquare>();

            if (obstacle)
            {
                GameplayPool.Single.ReturnObstacle(obstacle);
            }
        }
    }
}
