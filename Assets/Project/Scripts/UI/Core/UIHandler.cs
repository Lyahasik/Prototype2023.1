using UnityEngine;

using Prototype.Core;

namespace Prototype.UI.Core
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject textPromptStartGame;

        public static UIHandler Single;

        private void Awake()
        {
            Single = this;
        }

        private void OnEnable()
        {
            ProcessingGame.OnOverGame += OverGame;
        }

        private void OverGame()
        {
            textPromptStartGame.SetActive(true);
        }

        public void DeactivatePrompt()
        {
            textPromptStartGame.SetActive(false);
        }
    }
}
