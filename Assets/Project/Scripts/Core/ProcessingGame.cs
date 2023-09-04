using UnityEngine;

using Prototype.Gameplay.Player;
using Prototype.UI.Gameplay;

namespace Prototype.Core
{
    public class ProcessingGame : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;

        private bool _isStarted;

        private void OnEnable()
        {
            TouchArea.OnTouchUp += StartGame;
        }

        private void StartGame()
        {
            if (_isStarted)
                return;
            
            playerMovement.Activate();

            _isStarted = true;
        }
        
        private void OverGame()
        {
            playerMovement.Reset();

            _isStarted = false;
        }
    }
}
