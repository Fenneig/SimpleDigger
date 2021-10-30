using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private int _currentShovelAmount;
        [SerializeField] private int _currentGoldCollected;

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

        public event Action OnChanged;
        
        
    }

}