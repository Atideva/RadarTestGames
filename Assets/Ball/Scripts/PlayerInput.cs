using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ball.Scripts
{
    public class PlayerInput : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnInput = delegate {  }; 

        public void OnPointerDown(PointerEventData eventData)
        {
            OnInput();
        }
    }
}
