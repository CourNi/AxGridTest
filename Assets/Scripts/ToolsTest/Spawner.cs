using System.Collections;
using UnityEngine;
using AxGrid.Base;
using AxGrid.Model;

namespace ToolsTest
{
    public class Spawner : MonoBehaviourExtBind
    {
        [SerializeField]
        private ItemPrefab _itemPrefab;
        [SerializeField]
        private ItemPool _itemPool;
        private int _listCount;
        private Coroutine _coroutine;

        [Bind]
        private void OnGameStart()
        {
            _listCount = _itemPool.ItemList.Count;
            Spawn();
        }

        [Bind]
        private void OnGameOver()
        {
            StopCoroutine(_coroutine);
        }

        private void Spawn()
        {
            float randomDelay = Random.Range(1.5f, 5.0f);
            _coroutine = StartCoroutine(SpawnDelay(randomDelay));
        }

        private IEnumerator SpawnDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Item item = _itemPool.ItemList[Random.Range(0, _listCount)];
            ItemPrefab obj = Instantiate(_itemPrefab, transform.localPosition, Quaternion.identity, transform);
            obj.SetItem(item.ItemSprite, item.IsBone);
            Spawn();
        }
    }
}
