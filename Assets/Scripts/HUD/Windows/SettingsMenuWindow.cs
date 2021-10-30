using Model;
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

        public SettingsData Data { get; private set; }

        private void Start()
        {
            FillData();
            gameObject.SetActive(false);
        }

        public void OnReturn()
        {
            FillData();
            _mainMenuWindow.SetActive(true);
            gameObject.SetActive(false);
        }

        private void FillData()
        {
            Data = new SettingsData((int) _fieldSize.value,
                (int) _maxDepth.value,
                (int) _shovelAmount.value,
                (int) _goldToWin.value);
        }
    }
}