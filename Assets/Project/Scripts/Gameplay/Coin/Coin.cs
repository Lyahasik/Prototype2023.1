using UnityEngine;

using Prototype.Gameplay.ActiveArea;
using Prototype.Gameplay.Player;
using Prototype.UI.Progress;

namespace Prototype.Gameplay.Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private MovementInArea movementInArea;

        private void HitPlayer()
        {
            GameplayPool.Single.ReturnObstacle(PooledObjectType.Coin, movementInArea);
            CoinsManager.AddCoin(1);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!movementInArea.IsActive)
                return;

            if (other.GetComponent<PlayerMovement>())
            {
                HitPlayer();
            }
        }
    }
}
