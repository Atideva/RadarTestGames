using System;
using UnityEngine;

namespace Battle.Scripts
{
    public class Unit : MonoBehaviour, IDamageable, IHasTeam
    {
        [Space(10)]
        public float maxHp;
        public float damage;
        public float attackSpeed;
        public float attackRadius;
        [Range(0f, 0.5f)] public float attackCritChance;
        public float moveSpeed;

        [Space(10)]
        public UnitModel model;
        public UnitHitpoints hitpoints;
        public UnitHitpointsUI hitpointsUI;
        public UnitMovement movement;
        public UnitOrientation orientation;
        public UnitWeapon weapon;
        public UnitAI ai;
        public UnitDamageText dmgTakenText;
        public Transform attackRadiusCircle;
        public event Action<Unit> OnDeath;

        public void Init(SceneUnits sceneUnits)
        {
            hitpoints.SetMaxHp(maxHp);
            hitpoints.HealAll();
            hitpoints.OnDamaged += RefreshUI;
            hitpoints.OnDeath += Death;
            hitpointsUI.SetValue(hitpoints.Value);

            movement.SetMoveSpeed(moveSpeed);
            weapon.SetDamage(damage, attackSpeed, attackRadius, attackCritChance);
            ai.Init(sceneUnits, movement, orientation, weapon, Team);
            dmgTakenText.Init(hitpoints);
            
            attackRadiusCircle.localScale = Vector3.one * attackRadius;
        }

        void Death()
        {
            OnDeath?.Invoke(this);
            gameObject.SetActive(false);
        }

        void RefreshUI(float hpValue)
        {
            hitpointsUI.SetValue(hpValue);
        }

        public Team Team { get; private set; }

        public void SetTeam(Team team)
        {
            Team = team;
            model.SetBaseMaterial(team.UnitMaterial);
        }

        public void TakeDamage(float damage)
        {
            hitpoints.DecreaseHp(damage);
            hitpointsUI.SetValue(hitpoints.Value);
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
    }
}