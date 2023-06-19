using UnityEngine;
using UnityEngine.SceneManagement;

namespace Battle.Scripts
{
    public class SceneRestartButton : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
