using UnityEngine;

using Prototype.Gameplay.ActiveArea;
using Prototype.Gameplay.Player;
using Prototype.UI.Progress;

namespace Prototype.Gameplay.Coin
{
    [RequireComponent(typeof(AttractionToPlayer))]
    public class Coin : MonoBehaviour
    {
        [SerializeField] private MovementInArea movementInArea;

        private AttractionToPlayer _attractionToPlayer;

        private void Awake()
        {
            _attractionToPlayer = GetComponent<AttractionToPlayer>();
        }

        private void HitPlayer()
        {
            Debug.Log("Hit");
            GameplayPool.Single.ReturnObstacle(PooledObjectType.Coin, movementInArea);
            CoinsManager.AddCoin(1);

            transform.localPosition = Vector3.zero;
            _attractionToPlayer.IsActive = false;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!movementInArea.IsActive
                && !_attractionToPlayer.IsActive)
                return;
            
            Debug.Log("Trigger");

            if (other.GetComponent<PlayerMovement>())
            {
                HitPlayer();
            }
        }
    }
}
