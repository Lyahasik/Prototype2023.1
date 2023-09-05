using System;
using UnityEngine;

using Prototype.Gameplay.Player;
using Prototype.UI.Core;
using Prototype.UI.Progress;

namespace Prototype.Core
{
    public class ProcessingGame : MonoBehaviour
    {
        private bool _isStarted;

        public static ProcessingGame Single;
        
        public static event Action OnOverGame;

        public bool IsStarted => _isStarted;

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

            UIHandler.Single.DeactivatePrompt();
            _isStarted = true;
        }
        
        public void OverGame()
        {
            OnOverGame?.Invoke();
            CoinsManager.UpdateValue(0);

            _isStarted = false;
        }
    }
}
