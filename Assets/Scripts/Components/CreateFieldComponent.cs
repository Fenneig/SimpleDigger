using Model;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Components
{
    public class CreateFieldComponent : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _fieldItem;
        [SerializeField] [Range(0.1f, 0.4f)] private float _distanceBetweenFieldItems;
        [SerializeField] [Range(1, 100)] private int _goldSpawnChance;


        private void Start()
        {
            CreateGold();
            CreateField();
            FillPlayerData();
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private void FillPlayerData()
        {
            GameData.I.PlayerData.CurrentGoldCollected = 0;
            GameData.I.PlayerData.CurrentShovelAmount = GameData.I.Data.ShovelAmount;
        }

        private void CreateGold()
        {
            var fieldSize = GameData.I.Data.FieldSize;
            var maxDepth = GameData.I.Data.MaxDepth;
            var goldMap = new bool[fieldSize, fieldSize, maxDepth];

            for (var i = 0; i < fieldSize; i++)
            for (var j = 0; j < fieldSize; j++)
            for (var k = 0; k < maxDepth; k++)
            {
                var randomNum = Random.Range(1, 100);
                if (randomNum < _goldSpawnChance)
                    goldMap[i, j, k] = true;
            }

            GameData.I.IsCellContainGold = goldMap;
        }

        private void CreateField()
        {
            var fieldSize = GameData.I.Data.FieldSize;
            var containerSize = _container.GetComponent<SpriteRenderer>().size;
            //увеличиваю размер предмета под контейнер
            var itemLocalScale = new Vector3(containerSize.x / fieldSize, containerSize.y / fieldSize, 0);

            //уменьшаю на дистанцию между ячейками
            itemLocalScale = new Vector3(itemLocalScale.x - _distanceBetweenFieldItems,
                itemLocalScale.y - _distanceBetweenFieldItems, 0);

            //перезаписываю размер
            _fieldItem.transform.localScale = new Vector3(itemLocalScale.x, itemLocalScale.y, itemLocalScale.z);

            var startItemPosition = new Vector3((-containerSize.x + itemLocalScale.x) / 2 - _distanceBetweenFieldItems,
                (containerSize.y - itemLocalScale.y) / 2 - _distanceBetweenFieldItems, 0);

            //пересчет расстаяния между ячейками
            var newDistance = _distanceBetweenFieldItems * (1 + 1 / (fieldSize - 1f));
            var containerPos = _container.position;
            for (var i = 0; i < fieldSize; i++)
            {
                for (var j = 0; j < fieldSize; j++)
                {
                    var newXPos = i * (itemLocalScale.x + newDistance) + startItemPosition.x +
                                  _distanceBetweenFieldItems + containerPos.x;

                    var newYPos = -j * (itemLocalScale.y + newDistance) + startItemPosition.y +
                                  _distanceBetweenFieldItems + containerPos.y;

                    var newItemPosition = new Vector3(newXPos, newYPos, 0);

                    var instance = Instantiate(_fieldItem, newItemPosition, quaternion.identity, _container);
                    instance.SetActive(true);
                    var instanceParams = instance.GetComponent<DigComponent>();
                    instanceParams.X = j;
                    instanceParams.Y = i;
                }
            }
        }
    }
}