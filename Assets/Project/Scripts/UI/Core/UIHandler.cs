using UnityEngine;

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

        public void SetPromptActive(bool value)
        {
            textPromptStartGame.SetActive(value);
        }
    }
}
