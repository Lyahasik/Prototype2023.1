using UnityEngine;

using Prototype.Core;

namespace Prototype.Gameplay.ActiveArea
{
    public class MovementInArea : MonoBehaviour
    {
        [SerializeField] private float speedMove;
        
        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        private void OnEnable()
        {
            ProcessingGame.OnOverGame += OverGame;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (!_isActive)
                return;
            
            transform.Translate(Vector3.left * (speedMove * Time.deltaTime));
        }

        public void Activate(Vector3 position)
        {
            transform.position = position;
            
            _isActive = true;
        }

        public void Reset()
        {
            _isActive = false;
            
            transform.localPosition = Vector3.zero;
        }
        
        private void OverGame()
        {
            GameplayPool.Single.ReturnObstacle(PooledObjectType.Obstacle, this);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!_isActive)
                return;
            
            if (other.GetComponent<Area>())
                GameplayPool.Single.ReturnObstacle(PooledObjectType.Obstacle, this);
        }

    }
}
