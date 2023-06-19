using UnityEngine;

namespace Battle.Scripts
{
    public class UnitOrientation : MonoBehaviour
    {
        public Transform model;

        public void SetOrientation(Vector3 dir)
        {
            model.forward = dir;
        }
    }
}
