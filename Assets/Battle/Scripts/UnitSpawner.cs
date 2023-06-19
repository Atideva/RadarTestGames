using System.Collections.Generic;
using UnityEngine;

namespace Battle.Scripts
{
    public class UnitSpawner : MonoBehaviour
    {
        public Transform container;
        public List<Unit> unitPrefabs;

        public List<Unit> Spawn(int amount, int teamID)
        {
            var unis = new List<Unit>();
            for (var i = 0; i < amount; i++)
            {
                var r = Random.Range(0, unitPrefabs.Count);
                var unit = Instantiate(unitPrefabs[r], container);

                var unitName = unit.gameObject.name;
                var removeCloneWord = unitName.Substring(0, unitName.Length - 7);
                unit.gameObject.name = $"[Team {teamID}] {removeCloneWord}";

                unis.Add(unit);
            }

            return unis;
        }
    }
}