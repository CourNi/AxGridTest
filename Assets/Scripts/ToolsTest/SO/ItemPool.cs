using System.Collections.Generic;
using UnityEngine;

namespace ToolsTest
{
    [CreateAssetMenu(fileName = "ItemPool", menuName = "Items/New ItemPool")]
    public class ItemPool : ScriptableObject
    {
        [SerializeField]
        private List<Item> _itemList;

        public List<Item> ItemList { get => _itemList; }
    }
}