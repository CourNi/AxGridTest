using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolsTest
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/New Item", order = 1)]
    public class Item : ScriptableObject
    {
        [SerializeField]
        private Sprite _sprite;
        [SerializeField]
        private bool _isBone;

        public Sprite ItemSprite { get => _sprite; }
        public bool IsBone { get => _isBone; }
    }
}