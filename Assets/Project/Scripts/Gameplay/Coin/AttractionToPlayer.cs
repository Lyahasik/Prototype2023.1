using UnityEngine;

using Prototype.Gameplay.ActiveArea;
using Prototype.Gameplay.Player;

namespace Prototype.Gameplay.Coin
{
    public class AttractionToPlayer : MonoBehaviour
    {
        [SerializeField] private MovementInArea movementInArea;

        [Space]
        [SerializeField] private float checkDistance;
        [SerializeField] private float speedApproach;

        private Transform _transformPlayer;
        
        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        private void Start()
        {
            _transformPlayer = PlayerMovement.Single.transform;
        }

        private void Update()
        {
            CheckDistance();
            ApproachPlayer();
        }

        private void CheckDistance()
        {
            if (_isActive
                || Vector3.Distance(transform.position, _transformPlayer.position) > checkDistance)
                return;

            _isActive = true;
            movementInArea.IsActive = false;
        }

        private void ApproachPlayer()
        {
            if (!_isActive)
                return;

            Vector3 step = (_transformPlayer.position - transform.position).normalized;
            step *= speedApproach * Time.deltaTime;
            transform.Translate(step);
        }
    }
}
