using UnityEngine;

namespace Battle.Scripts
{
    public class UnitMovement : MonoBehaviour
    {
        float _moveSpeed;
        public Rigidbody rb;
        public void SetMoveSpeed(float speed) => _moveSpeed = speed;

        public void Move(Vector3 dir)
        {
            rb.velocity = dir.normalized * (_moveSpeed);
        }

        public void Stop()
        {
            rb.velocity = Vector3.zero;
        }
    }
}