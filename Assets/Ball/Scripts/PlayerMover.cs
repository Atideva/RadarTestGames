 
using DG.Tweening;
using UnityEngine;

namespace Ball.Scripts
{
    public class PlayerMover : MonoBehaviour
    {
        float _speed;
        public Vector3 direction;
        Rigidbody _rb;
        bool _isEnable;
        float _spdMult;

        public void Init(Rigidbody rb, float horizontalSpeed)
        {
            _rb = rb;
            _speed = horizontalSpeed;
            _spdMult = 1f;
        }

        void Update()
        {
            if (!_isEnable) return;
            _rb.velocity = direction * (_speed * _spdMult/2);
        }

        public void Enable() => _isEnable = true;
        public void Disable() => _isEnable = false;
        public void Reset() => _spdMult = 1;
        public void SwapDirection() => direction *= -1;

        public void SetSpeedBoost(float multiplier)
            => DOVirtual.Float(_spdMult, multiplier*.8f, 7, value => _spdMult = value);
    }
}