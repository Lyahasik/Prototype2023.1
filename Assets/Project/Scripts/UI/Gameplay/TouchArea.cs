using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Prototype.UI.Gameplay
{
    public class TouchArea : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public static event Action OnTouchDown;
        public static event Action OnTouchUp;
        
        public void OnPointerUp(PointerEventData eventData)
        {
            OnTouchUp?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnTouchDown?.Invoke();
        }
    }
}
