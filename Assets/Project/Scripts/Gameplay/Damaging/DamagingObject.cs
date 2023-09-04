using UnityEngine;

using Prototype.Core;
using Prototype.Gameplay.Player;

namespace Prototype.Gameplay.Damaging
{
    [RequireComponent(typeof(Collider2D))]
    public class DamagingObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<PlayerMovement>())
                ProcessingGame.Single.OverGame();
        }
    }
}
