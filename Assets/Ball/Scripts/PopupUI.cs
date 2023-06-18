using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ball.Scripts
{
    public class PopupUI : MonoBehaviour
    {
        public CanvasGroup group;
        public Button button;

        void Start()
        {
            button.onClick.AddListener(Click);
        }

        public event Action OnClick = delegate { };

        void Click() => OnClick();

        public void Show()
        {
            group.alpha = 1;
            group.interactable = true;
            group.blocksRaycasts = true;
        }

        public void Hide()
        {
            group.alpha = 0;
            group.interactable = false;
            group.blocksRaycasts = false;
        }
    }
}