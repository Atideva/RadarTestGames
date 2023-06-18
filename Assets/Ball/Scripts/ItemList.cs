using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ball.Scripts
{
    public class ItemList : MonoBehaviour
    {
        ItemSpawner _dmgSpawner;
        ItemSpawner _scoreSpawner;
        public bool IsScore(Transform t) => _scoreSpawner.Items.Any(item => item.transform == t);
        public bool IsDamage(Transform t) => _dmgSpawner.Items.Any(item => item.transform == t);
        
        public IReadOnlyCollection<Item> ScoreItems => _scoreSpawner.Items;
        public IReadOnlyCollection<Item> DmgItems => _dmgSpawner.Items;

        public void Init(ItemSpawner dmgSpawner, ItemSpawner scoreSpawner)
        {
            _scoreSpawner = scoreSpawner;
            _dmgSpawner = dmgSpawner;
        }
    }
}