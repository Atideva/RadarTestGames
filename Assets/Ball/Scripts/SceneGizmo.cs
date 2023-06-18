using UnityEngine;

namespace Ball.Scripts
{
    public class SceneGizmo : MonoBehaviour
    {
        public Color gizmoColor;
        public GizmoType gizmoType;
        public float sphereSize;
        public enum GizmoType
        {
            Sphere,
            Cube
        }

        void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            switch (gizmoType)
            {
                case GizmoType.Sphere:
                    Gizmos.DrawSphere(transform.position, sphereSize);
                    break;
                case GizmoType.Cube:
                    Gizmos.DrawCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z));
                    break;
            }
        }
    }
}