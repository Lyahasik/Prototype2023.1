using UnityEngine;

namespace Prototype.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private ParticleSystem effectMovement;

        private void Start()
        {
            Activate();
        }

        public void Activate()
        {
            effectMovement.Play();
        }

        public void Reset()
        {
            effectMovement.Stop();
        }
    }
}
