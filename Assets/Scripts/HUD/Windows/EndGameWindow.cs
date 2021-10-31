using Model;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.Windows
{
    public class EndGameWindow : MonoBehaviour
    {
        [SerializeField] private Text _endGameText;

        private void Start()
        {
            GameData.I.PlayerData.OnGameEnded += ShowWindow;
            gameObject.SetActive(false);

        }

        private void ShowWindow()
        {
            gameObject.SetActive(true);
            _endGameText.text = GameData.I.PlayerData.IsWin ? "You win!" : "You lose!";
        }

        private void OnDestroy()
        {
            GameData.I.PlayerData.OnGameEnded -= ShowWindow;
        }
    }
}