using UnityEngine;
using AxGrid.Base;

namespace ToolsTest
{
    public class ItemPrefab : MonoBehaviourExt
    {
        private bool _isBone;

        private void OnTriggerEnter2D(Collider2D col)
        {
            col.GetComponent<IColliderHandler>()?.OnCollide(_isBone);
            Destroy(gameObject);
        }

        public void SetItem(Sprite sprite, bool isBone)
        {
            _isBone = isBone;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}