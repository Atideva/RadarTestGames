using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Ball.Scripts
{
    public class Player : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] int maxLives = 3;
        int _lives;

        [Header("Speed")]
        [SerializeField] float verticalSpeed;
        [SerializeField] float horizontalSpeed;

        [Space(10)]
        [SerializeField] PlayerMover mover;
        [SerializeField] PlayerController controller;
        [SerializeField] Rigidbody body;
        [SerializeField] Transform model;

        [Space(10)]
        [SerializeField] BallAnimation hitAnimation;
        [SerializeField] BallAnimation scoreAnimation;
        [SerializeField] ParticleSystem moveVfx;
        ItemList _list;
        TextMeshProUGUI _livesTxt;
        public float VerticalSpeed => verticalSpeed * _spdMult;

        public float SpeedMult => _spdMult;

        public event Action OnScoreAdd = delegate { };
        public event Action OnDeath = delegate { };
        float _spdMult;

        public void Init(ItemList list, PlayerInput input, TextMeshProUGUI livesTxt)
        {
            _livesTxt = livesTxt;
            _list = list;
            mover.Init(body, horizontalSpeed);
            controller.Init(mover, input);
            RefreshText();
            Reset();
        }

        public void SetSpeedBoost(float multiplier)
        {
            DOVirtual.Float(_spdMult, multiplier, 7, value => _spdMult = value);
            mover.SetSpeedBoost(multiplier);
        }

        public void Reset()
        {
            transform.localPosition = Vector3.zero;
            _lives = maxLives;
            _spdMult = 1f;
            mover.Reset();
            RefreshText();
        }

        public void DisableMovement()
        {
            moveVfx.gameObject.SetActive(false);
            mover.Disable();
        }

        public void EnableMovement()
        {
            moveVfx.gameObject.SetActive(true);
            mover.Enable();
        }

        void OnTriggerEnter(Collider other)
        {
            var t = other.transform;

            if (_list.IsScore(t))
            {
                scoreAnimation.Play();
                OnScoreAdd();
            }

            if (_list.IsDamage(t))
            {
                _lives--;
                hitAnimation.Play();
                if (_lives <= 0)
                {
                    _lives = 0;
                    OnDeath();
                }

                RefreshText();
            }

            other.gameObject.SetActive(false);
        }

        void RefreshText()
        {
            _livesTxt.text = $"HP: {_lives}";

            _livesTxt.color = Color.red;
            _livesTxt.DOColor(Color.green, 0.2f).SetDelay(0.6f);

            var t = _livesTxt.transform.parent;
            t.DOScale(1.5f, 0.2f).OnComplete(()
                => t.DOScale(1f, 0.2f));
        }
    }
}