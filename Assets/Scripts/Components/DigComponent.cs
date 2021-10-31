using Model;
using UnityEngine;
using Utils;

namespace Components
{
    public class DigComponent : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        public int X { get; set; }
        public int Y { get; set; }

        private int _depth;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _depth = 0;
            ReColorCell();
        }

        public void Dig()
        {
            if (!GameData.I.PlayerData.IsGameRunning) return;
            
            if (IsCellContainGold())
            {
                GameData.I.PlayerData.CurrentGoldCollected++;
                GameData.I.IsCellContainGold[X, Y, _depth] = false;
                ReColorCell();
                return;
            }

            if (_depth >= GameData.I.Data.MaxDepth - 1) return;
            GameData.I.PlayerData.CurrentShovelAmount--;
            _depth++;
            ReColorCell();
        }

        private void EndGameCheck()
        {
            if (GameData.I.PlayerData.CurrentGoldCollected == GameData.I.Data.GoldToWin)
            {
                GameData.I.PlayerData.IsWin = true;
                GameData.I.PlayerData.IsGameRunning = false;
            }
            if (GameData.I.PlayerData.CurrentShovelAmount == 0)
            {
                GameData.I.PlayerData.IsWin = false;
                GameData.I.PlayerData.IsGameRunning = false;
            }
        }

        private void ReColorCell()
        {
            if (IsCellContainGold())
            {
                _sprite.color = CellColorUtils.GoldColor;
            }
            else
            {
                var colorAlpha = 1f - _depth / (float) (GameData.I.Data.MaxDepth - 1);
                var tempColor = CellColorUtils.DefaultColor;
                _sprite.color = new Color(tempColor.r, tempColor.g, tempColor.b, colorAlpha);
            }
            EndGameCheck();

        }

        private bool IsCellContainGold()
        {
            return GameData.I.IsCellContainGold[X, Y, _depth];
        }
    }
}