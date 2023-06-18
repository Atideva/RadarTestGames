using UnityEngine;

namespace Ball.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        PlayerMover _mover;
        PlayerInput _input;

        public void Init(PlayerMover mover, PlayerInput input)
        {
            _mover = mover;
            input.OnInput += SwapDirection;
        }

        void SwapDirection()
        {
            _mover.SwapDirection();
        }
    }
}