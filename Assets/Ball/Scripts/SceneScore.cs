using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Ball.Scripts
{
    public class SceneScore : MonoBehaviour
    {
        [SerializeField] int score;
        TextMeshProUGUI _txt;
        public event Action<int> OnChange = delegate { };

        public void Init(Player player, TextMeshProUGUI txt)
        {
            _txt = txt;
            player.OnScoreAdd += AddScore;
        }

        public void Reset()
        {
            score = 0;
            RefreshText();
        }

        void AddScore()
        {
            score++;
            RefreshText();
            OnChange(score);
        }

        void RefreshText()
        {
            _txt.text = $"Score: {score}";

            var t = _txt.transform.parent;
            t.DOScale(1.3f, 0.1f).OnComplete(()
                => t.DOScale(1f, 0.1f));
        }
    }
}