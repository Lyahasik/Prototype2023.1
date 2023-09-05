using System;
using UnityEngine;

namespace Prototype.UI.Progress
{
    public class CoinsManager : MonoBehaviour
    {
        public static event Action<int> OnUpdateValue;

        private static int currentValue;

        public static void AddCoin(int value)
        {
            currentValue += value;
            UpdateValue(currentValue);
        }

        public static void UpdateValue(int value)
        {
            currentValue = value;
            OnUpdateValue?.Invoke(value);
        }
    }
}
