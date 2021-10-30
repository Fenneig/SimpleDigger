using System;
using UnityEngine;

namespace Model
{
    public class GameData : MonoBehaviour
    {
        public static GameData I { get; private set; }

        [SerializeField] private SettingsData _data;
        [SerializeField] private int _chanceToSpawnGold;

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
        
        public void GenerateGold()
        {
            
        }
    }
    

    [Serializable]
    public struct SettingsData
    {
        [SerializeField] private int _fieldSize;
        [SerializeField] private int _maxDepth;
        [SerializeField] private int _shovelAmount;
        [SerializeField] private int _goldToWin;

        public int FieldSize
        {
            get => _fieldSize;
            set => _fieldSize = value;
        }

        public int MaxDepth
        {
            get => _maxDepth;
            set => _maxDepth = value;
        }

        public int ShovelAmount
        {
            get => _shovelAmount;
            set => _shovelAmount = value;
        }

        public int GoldToWin
        {
            get => _goldToWin;
            set => _goldToWin = value;
        }

        public SettingsData(int fieldSize, int maxDepth, int shovelAmount, int goldToWin)
        {
            _fieldSize = fieldSize;
            _maxDepth = maxDepth;
            _shovelAmount = shovelAmount;
            _goldToWin = goldToWin;
        }
    }
}