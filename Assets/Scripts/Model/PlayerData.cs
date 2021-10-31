using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private int _currentShovelAmount;
        [SerializeField] private int _currentGoldCollected;
        private bool _isGameRunning;


        public event Action OnGameEnded;

        public bool IsGameRunning
        {
            get => _isGameRunning;
            set
            {
                _isGameRunning = value;
                if (value == false) OnGameEnded?.Invoke();
            }
        }

        public bool IsWin { get; set; }

        public event Action OnChanged;


        public int CurrentShovelAmount
        {
            get => _currentShovelAmount;
            set
            {
                _currentShovelAmount = value;
                OnChanged?.Invoke();
            }
        }

        public int CurrentGoldCollected
        {
            get => _currentGoldCollected;
            set
            {
                _currentGoldCollected = value;
                OnChanged?.Invoke();
            }
        }
    }
}