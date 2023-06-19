using TMPro;
using UnityEngine;

namespace Battle.Scripts
{
    public class SceneTimeUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI txtMin;
        [SerializeField] TextMeshProUGUI txtSec;
        [SerializeField] CanvasGroup group;

        public void Show() => group.alpha = 1;
        public void Hide() => group.alpha = 0;

        public void RefreshText(int minutes, int seconds)
        {
            if (seconds >= 60) seconds -= 60;

            var minPrefix = minutes < 10 ? "0" : "";
            var secPrefix = seconds < 10 ? "0" : "";
            txtMin.text = minPrefix + minutes;
            txtSec.text = secPrefix + seconds;
        }
    }
}