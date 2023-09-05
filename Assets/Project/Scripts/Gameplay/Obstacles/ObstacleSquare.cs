using UnityEngine;

using Prototype.Core;
using Prototype.Gameplay.ActiveArea;

namespace Prototype.Gameplay.Obstacles
{
    [RequireComponent(typeof(MovementInArea))]
    public class ObstacleSquare : Obstacle
    {
        private MovementInArea _movementInArea;
        
        private void Awake()
        {
            _movementInArea = GetComponent<MovementInArea>();
        }
        
        private void OnEnable()
        {
            ProcessingGame.OnOverGame += OverGame;
        }

        public void Activate(Vector3 position)
        {
            transform.position = position;
            
            _movementInArea.Activate();
        }

        public void Reset()
        {
            transform.localPosition = Vector3.zero;
                
            _movementInArea.Deactivate();
        }

        private void OverGame()
        {
            GameplayPool.Single.ReturnObstacle(this);
        }
    }
}
