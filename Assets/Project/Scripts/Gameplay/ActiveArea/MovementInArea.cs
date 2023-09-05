using UnityEngine;

namespace Prototype.Gameplay.ActiveArea
{
    public class MovementInArea : MonoBehaviour
    {
        [SerializeField] private float speedMove;
        
        private bool _isActive;

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

        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }
    }
}
