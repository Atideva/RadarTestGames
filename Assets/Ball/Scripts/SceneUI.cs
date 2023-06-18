using TMPro;
using UnityEngine;

namespace Ball.Scripts
{
    public class SceneUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI livesTxt;
        [SerializeField] TextMeshProUGUI scoreTxt;
        [SerializeField] PlayerInput playerInput;
        [SerializeField] PopupUI startGame;
        [SerializeField] PopupUI lose;

        public TextMeshProUGUI LivesTxt => livesTxt;
        public TextMeshProUGUI ScoreTxt => scoreTxt;
        public PlayerInput PlayerInput => playerInput;

        public PopupUI Lose => lose;

        public PopupUI StartGame => startGame;
    }
}
