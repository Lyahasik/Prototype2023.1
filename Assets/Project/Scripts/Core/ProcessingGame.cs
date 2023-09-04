using UnityEngine;

using Prototype.Gameplay.Player;
using Prototype.UI.Core;

namespace Prototype.Core
{
    public class ProcessingGame : MonoBehaviour
    {
        private bool _isStarted;

        public static ProcessingGame Single;

        private void Awake()
        {
            Single = this;
        }

        private void OnEnable()
        {
            InputController.OnTouchDown += StartGame;
        }

        private void StartGame()
        {
            if (_isStarted)
                return;
            
            PlayerMovement.Single.Activate();

            UIHandler.Single.SetPromptActive(false);
            _isStarted = true;
        }
        
        public void OverGame()
        {
            PlayerMovement.Single.Reset();

            UIHandler.Single.SetPromptActive(true);
            _isStarted = false;
        }
    }
}
