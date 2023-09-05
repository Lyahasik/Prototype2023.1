using UnityEngine;

using Prototype.Core;
using Prototype.Gameplay.Player;

namespace Prototype.Gameplay.Obstacles
{
    [RequireComponent(typeof(Collider2D))]
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<PlayerMovement>())
                ProcessingGame.Single.OverGame();
        }
    }
}
