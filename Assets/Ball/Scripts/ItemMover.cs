using UnityEngine;

namespace Ball.Scripts
{
    public class ItemMover : MonoBehaviour
    {
        Player _player;
        ItemList _list;

        public void Init(Player player, ItemList list)
        {
            _list = list;
            _player = player;
        }

        void Update()
        {
            foreach (var item in _list.ScoreItems)
                Move(item);

            foreach (var item in _list.DmgItems)
                Move(item);
        }

        void Move(Item item)
        {
            item.transform.Translate(-transform.forward * (_player.VerticalSpeed * Time.deltaTime));
        }
    }
}