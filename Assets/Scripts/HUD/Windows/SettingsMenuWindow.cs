using UnityEngine;
using UnityEngine.UI;

namespace HUD.Windows
{
    public class SettingsMenuWindow : MonoBehaviour
    {
        [SerializeField] private Slider _fieldSize;
        [SerializeField] private Slider _maxDepth;
        [SerializeField] private Slider _shovelAmount;
        [SerializeField] private Slider _goldToWin;

        [SerializeField] private GameObject _mainMenuWindow;

        public void OnReturn()
        {
            _mainMenuWindow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}