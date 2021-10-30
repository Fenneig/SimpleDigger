using UnityEngine;
using UnityEngine.SceneManagement;

namespace Windows
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private string _levelName;

        [SerializeField] private GameObject _settingsMenuContainer;
        
        public void OnStart()
        {
            SceneManager.LoadScene(_levelName);
        }

        public void OnSettings()
        {
            _settingsMenuContainer.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnExit()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}