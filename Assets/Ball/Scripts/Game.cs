using System.Collections.Generic;
using UnityEngine;

namespace Ball.Scripts
{
    public class Game : MonoBehaviour
    {
        [Header("Spawn Rate")]
        public float dmgPerMinute;
        public float scorePerMinute;

        [Space(10)]
        public List<SpeedBoostData> speedData;

        [Space(10)]
        public Player player;
        public SceneScore sceneScore;
        public SceneUI ui;

        [Space(10)]
        public ItemSpawner dmgSpawner;
        public ItemSpawner scoreSpawner;

        [Space(10)]
        public ItemList itemList;
        public ItemRecycler itemRecycler;
        public ItemMover itemMover;
        int _level;

        void Start()
        {
            player.Init(itemList, ui.PlayerInput, ui.LivesTxt);
            player.OnDeath += Lose;
            player.DisableMovement();

            sceneScore.Init(player, ui.ScoreTxt);
            sceneScore.OnChange += IncreaseSpeed;

            dmgSpawner.Init(dmgPerMinute, player);
            scoreSpawner.Init(scorePerMinute, player);

            itemList.Init(dmgSpawner, scoreSpawner);
            itemMover.Init(player, itemList);

            ui.LivesTxt.enabled = false;
            ui.ScoreTxt.enabled = false;
            ui.Lose.Hide();
            ui.StartGame.Show();
            ui.StartGame.OnClick += StartGame;
        }


        void IncreaseSpeed(int score)
        {
            if (_level >= speedData.Count - 1) return;

            var require = speedData[_level].score;
            if (score < require) return;

            var boost = speedData[_level].speedMultiplier;
            player.SetSpeedBoost(boost);
            _level++;
        }

        void StartGame()
        {
            ui.LivesTxt.enabled = true;
            ui.ScoreTxt.enabled = true;
            ui.StartGame.Hide();
            player.EnableMovement();
            dmgSpawner.StartSpawn();
            scoreSpawner.StartSpawn();
        }

        void Lose()
        {
            ui.Lose.Show();
            ui.Lose.OnClick += Restart;
            player.DisableMovement();
            dmgSpawner.Stop();
            scoreSpawner.Stop();
        }

        void Restart()
        {
            ui.StartGame.Show();
            ui.Lose.Hide();
            player.Reset();
            sceneScore.Reset();
        }
    }

    [System.Serializable]
    public class SpeedBoostData
    {
        public int score;
        public float speedMultiplier;
    }
}