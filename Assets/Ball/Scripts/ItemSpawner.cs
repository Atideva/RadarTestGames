using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Random;


namespace Ball.Scripts
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] Item prefab;
        [SerializeField] List<Transform> spawnPositions = new();

        public IReadOnlyCollection<Item> Items => _items;
        readonly HashSet<Item> _items = new();
        float _timer;
        bool _isRun;
        float _spawnTime;
        Player _player;


        public void Init(float spawnPerMin, Player player)
        {
            _player = player;
            _spawnTime = 60 / spawnPerMin;
        }

        public void StartSpawn()
        {
            _isRun = true;
        }

        public void Stop()
        {
            _isRun = false;
        }

        void FixedUpdate()
        {
            if (!_isRun) return;

            _timer -= Time.fixedDeltaTime * (_player.SpeedMult*_player.SpeedMult);
            if (_timer > 0) return;

            _timer = _spawnTime;
            Spawn();
        }

        bool IsPooled => _items.Any(i => !i.gameObject.activeInHierarchy);

        Item GetItem() => IsPooled
            ? _items.FirstOrDefault(i => !i.gameObject.activeInHierarchy)
            : Instantiate(prefab, transform);

        void Spawn()
        {
            var r = Range(0, spawnPositions.Count);
            var pos = spawnPositions[r].position;

            var item = GetItem();
            item.gameObject.SetActive(true);
            item.transform.position = pos;

            _items.Add(item);
        }
    }
}