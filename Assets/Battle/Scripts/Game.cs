using System.Collections.Generic;
using UnityEngine;

namespace Battle.Scripts
{
    [System.Serializable]
    public class TeamData
    {
        public Team team;
        public int size;
    }

    public class Game : MonoBehaviour
    {
        public SceneUnits units;
        public UnitSpawner spawner;
        public List<TeamData> teams;

        void Start()
        {
            for (var i = 0; i < teams.Count; i++)
            {
                var data = teams[i];
                var army = spawner.Spawn(data.size, i + 1);
                data.team.Init(army);
                units.SetUnits(data.team, army);
            }

            units.InitAll();
        }
    }
}