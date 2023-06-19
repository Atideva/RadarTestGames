using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.Scripts
{
    public class UnitWeapon : MonoBehaviour
    {
        public ParticleSystem shootVfx;
        float _dmg;
        float _attackSpeed;
        float _radius;
        float _critChance;
        float _cooldown;
        float _timer;
        bool weaponReady;
        public float Radius => _radius;

        public void SetDamage(float dmg, float attackSpeed, float radius, float critChance)
        {
            _cooldown = 1 / attackSpeed;
            _critChance = critChance;
            _radius = radius;
            _attackSpeed = attackSpeed;
            _dmg = dmg;
        }

        public void Shoot(Unit target)
        {
            if (!weaponReady) return;

            shootVfx.gameObject.SetActive(true);
            _timer = _cooldown;
            weaponReady = false;

            var r = Random.Range(0.8f, 1.2f);
            var isCrit = Random.Range(0, 1f) < _critChance;
            var critMult = isCrit ? 3 : 1f;
            var dmg = _dmg * r * critMult;
            target.TakeDamage(dmg);
        }

        void FixedUpdate()
        {
            if (weaponReady) return;

            _timer -= Time.fixedDeltaTime;
            if (_timer > 0) return;

            weaponReady = true;
        }
    }
}