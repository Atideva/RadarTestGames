using System;
using UnityEngine;

namespace Battle.Scripts
{
    public class SceneTime : MonoBehaviour
    {
        [SerializeField] SceneTimeUI ui;

        [SerializeField] int minutes;
        [SerializeField] int seconds;
        float _timer;
        bool _isPause;

        public int Minutes => minutes;
        public int Seconds => seconds;
        public event Action OnTimeExpired = delegate { };

        void Start()
        {
            var totalSec = 0;
            minutes = totalSec / 60;
            seconds = totalSec % 60;

            ui.Show();
            ui.RefreshText(minutes, seconds);
        }
 
        void FixedUpdate()
        {
            if (_isPause) return;
            _timer += Time.fixedDeltaTime;

            if (_timer < 1) return;
            _timer -= 1;

            seconds++;
            if (seconds >= 60)
            {
                seconds -= 60;
                minutes++;

                if (minutes <= 0 && seconds <= 0)
                    OnTimeExpired();
            }

            ui.RefreshText(minutes, seconds);
        }
    }
}