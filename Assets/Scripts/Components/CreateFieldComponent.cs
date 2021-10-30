using Model;
using Unity.Mathematics;
using UnityEngine;

namespace Components
{
    public class CreateFieldComponent : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _fieldItem;
        [SerializeField] [Range(0.1f, 0.4f)] private float _distanceBetweenFieldItems;

        private void Start()
        {
            CreateField();
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
                }
            }
        }
    }
}