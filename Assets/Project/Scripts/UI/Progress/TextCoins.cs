using TMPro;
using UnityEngine;

namespace Prototype.UI.Progress
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextCoins : MonoBehaviour
    {
        private TMP_Text text;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            CoinsManager.OnUpdateValue += UpdateValue;
        }

        private void UpdateValue(int value)
        {
            text.text = value.ToString();
        }
    }
}
