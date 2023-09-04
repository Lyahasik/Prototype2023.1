using System;
using UnityEngine;

namespace Prototype.Core
{
    public class InputController : MonoBehaviour
    {
        public static event Action OnTouchDown;
        public static event Action OnTouchUp;
        
        private void Update()
        {
            ProcessingInput();
        }

        private void ProcessingInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                TouchDown();
            
            if (Input.GetKeyUp(KeyCode.Space))
                TouchUp();
        }

        public static void TouchDown()
        {
            OnTouchDown?.Invoke();
        }

        public static void TouchUp()
        {
            OnTouchUp?.Invoke();
        }
    }
}
