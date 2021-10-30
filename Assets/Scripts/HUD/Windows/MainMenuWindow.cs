using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD.Windows
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private string _levelName;
        [SerializeField] private GameObject _settingsMenuContainer;

        public void OnStart()
        {
            var data = _settingsMenuContainer.GetComponent<SettingsMenuWindow>().Data;
            GameData.I.Data = data;
            Debug.Log($"{data.FieldSize} {data.MaxDepth} {data.ShovelAmount} {data.GoldToWin}");
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