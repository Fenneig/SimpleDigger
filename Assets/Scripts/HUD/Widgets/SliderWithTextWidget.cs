using UnityEngine;
using UnityEngine.UI;

namespace HUD.Widgets
{
    public class SliderWithTextWidget : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;

        private string _defaultText;

        private void Start()
        {
            _defaultText = _text.text;
            _slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
            OnSliderValueChanged();
        }

        private void OnSliderValueChanged()
        {
            _text.text = $"{_defaultText} {_slider.value}";
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(delegate { OnSliderValueChanged(); });
        }
    }
}