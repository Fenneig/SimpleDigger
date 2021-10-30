using Model;
using UnityEngine;

namespace HUD.Windows
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsMenuContainer;

        public void OnStart()
        {
            var data = _settingsMenuContainer.GetComponent<SettingsMenuWindow>().Data;
            GameData.I.Data = data;
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