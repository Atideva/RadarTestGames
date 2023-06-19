using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.Scripts
{
    public class Team : MonoBehaviour
    {
        [SerializeField] Material unitMaterial;
        [Header("DEBUG")]
        [SerializeField] List<Unit> _units;
          Transform[] positions;
        public Material UnitMaterial => unitMaterial;

        public List<Unit> Units => _units;

        public void Init(List<Unit> units)
        {
            positions = GetComponentsInChildren<Transform>();
            _units = units;
            foreach (var unit in units)
            {
                unit.SetTeam(this);
            }

            var placed = 0;
            var pos = positions.ToList();
            while (placed < units.Count)
            {
                var r = Random.Range(0, pos.Count);
                units[placed].transform.position = pos[r].position;
                placed++;

                pos.RemoveAt(r);
                if (pos.Count == 0)
                    pos = positions.ToList();
            }
        }
    }
}