using UnityEngine;

namespace Model
{
    public class GameData : MonoBehaviour
    {
        public static GameData I { get; private set; }

        [SerializeField] private SettingsData _data;
        [SerializeField] private PlayerData _playerData;
        public bool[,,] IsCellContainGold { get; set; }
        public PlayerData PlayerData => _playerData;

        public SettingsData Data
        {
            get => _data;
            set => _data = value;
        }

        private void Awake()
        {
            if (!I)
            {
                I = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}