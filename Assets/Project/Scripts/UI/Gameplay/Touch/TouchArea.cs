using UnityEngine;
using UnityEngine.EventSystems;

using Prototype.Core;

namespace Prototype.UI.Gameplay.Touch
{
    public class TouchArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            InputController.TouchDown();
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            InputController.TouchUp();
        }
    }
}
