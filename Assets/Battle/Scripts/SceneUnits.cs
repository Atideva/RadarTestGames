using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.Scripts
{
    public class SceneUnits : MonoBehaviour
    {
        readonly Dictionary<Team, List<Unit>> _units = new();
        public IReadOnlyDictionary<Team, List<Unit>> Units => _units;
        public List<Unit> GetEnemyUnits(Team team) => _units.FirstOrDefault(t => t.Key != team).Value;

        public void SetUnits(Team team, List<Unit> units)
        {
            if (_units.ContainsKey(team)) return;
            _units.Add(team, units);
        }

        public void InitAll()
        {
            foreach (var unit in _units.SelectMany(pair => pair.Value))
            {
                unit.Init(this);
                unit.OnDeath += Remove;
            }
        }

        void Remove(Unit unit)
        {
            var list = _units[unit.Team];
            list.Remove(unit);
        }
        
    }
}