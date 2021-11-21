using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ResetButton : MonoBehaviour
    {
        
        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}