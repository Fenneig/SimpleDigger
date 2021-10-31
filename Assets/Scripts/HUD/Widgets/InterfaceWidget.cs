using Model;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.Widgets
{
    public class InterfaceWidget : MonoBehaviour
    {
        [SerializeField] private Text _shovelsAmountText;
        [SerializeField] private Text _goldAmountText;

        private string _shovelDefaultText;
        private string _goldDefaultText;

        private void OnEnable()
        {
            _shovelDefaultText = _shovelsAmountText.text;
            _goldDefaultText = _goldAmountText.text;

            _shovelsAmountText.text += GameData.I.PlayerData.CurrentShovelAmount.ToString();
            _goldAmountText.text += GameData.I.PlayerData.CurrentGoldCollected.ToString();

            GameData.I.PlayerData.OnChanged += OnChanged;
        }

        private void OnChanged()
        {
            _shovelsAmountText.text = $"{_shovelDefaultText} {GameData.I.PlayerData.CurrentShovelAmount.ToString()}";
            _goldAmountText.text = $"{_goldDefaultText} {GameData.I.PlayerData.CurrentGoldCollected.ToString()}";
        }

        private void OnDestroy()
        {
            GameData.I.PlayerData.OnChanged -= OnChanged;
        }
    }
}