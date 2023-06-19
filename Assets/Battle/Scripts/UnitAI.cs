using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Battle.Scripts
{
    public class UnitAI : MonoBehaviour
    {
        public SpriteRenderer weaponRadiusCircle;
        SceneUnits _sceneUnits;
        UnitMovement _movement;
        Team _team;

        UnitWeapon _weapon;
        UnitOrientation _orientation;

        public void Init(SceneUnits sceneUnits,
            UnitMovement movement, UnitOrientation orientation, UnitWeapon weapon, Team team)
        {
            _orientation = orientation;
            _sceneUnits = sceneUnits;
            _movement = movement;
            _weapon = weapon;
            _team = team;
        }

        void Update()
        {
            var targets = _sceneUnits.GetEnemyUnits(_team);
            var closest = GetClosest(targets);

            var dist = Vector3.Distance(closest.transform.position, transform.position);
            var dir = (closest.transform.position - transform.position).normalized;

            if (dist >= _weapon.Radius + 0.5f)
            {
                _movement.Move(dir);
                _orientation.SetOrientation(dir);
                
                weaponRadiusCircle.color = Color.white;
            }
            else
            {
                _movement.Stop();
                _orientation.SetOrientation(dir);
                _weapon.Shoot(closest);

                weaponRadiusCircle.color = Color.red;
                weaponRadiusCircle.DOFade(0.3f, 0);
            }
        }

        Unit GetClosest(List<Unit> targets)
        {
            var minDistance = 10000f;
            Unit closet = null;
            foreach (var unit in targets)
            {
                var v = transform.position - unit.transform.position;
                var dist = v.sqrMagnitude;
                if (dist >= minDistance) continue;
                closet = unit;
                minDistance = dist;
            }

            return closet;
        }
    }
}