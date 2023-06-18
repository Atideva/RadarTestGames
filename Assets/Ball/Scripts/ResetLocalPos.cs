using UnityEngine;

namespace Ball.Scripts
{
     public class ResetLocalPos : MonoBehaviour
     {
          void Awake()
          {
               transform.localPosition = Vector3.zero;
          }
     }
}
