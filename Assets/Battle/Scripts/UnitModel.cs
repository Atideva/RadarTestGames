using UnityEngine;

namespace Battle.Scripts
{
    public class UnitModel : MonoBehaviour
    {
        public MeshRenderer mesh;
        Material _material;

        public void SetBaseMaterial(Material material)
        {
            _material = material;
            mesh.material = material;
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
