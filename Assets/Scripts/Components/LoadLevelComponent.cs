using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{ 
    public class LoadLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _levelName;

        public void LoadLevel()
        {
            SceneManager.LoadScene(_levelName);
        }
    }
}