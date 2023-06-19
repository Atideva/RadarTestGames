using System;
using UnityEngine;

namespace Battle.Scripts
{
    public class UnitHitpoints : MonoBehaviour
    {
        public float MaxHp { get; private set; }
        float _hp;
        public event Action OnDeath;
        public event Action<float> OnDamaged;
 
        public float Value => _hp / MaxHp;
        public void SetMaxHp(float maxHp)
        {
            MaxHp = maxHp;
        }

        public void HealAll()
        {
            _hp = MaxHp;
        }

        public void DecreaseHp(float value)
        {
            _hp -= value;
            OnDamaged?.Invoke(value);

            if (_hp > 0) return;
            _hp = 0;
            OnDeath?.Invoke();
        }
    }
}