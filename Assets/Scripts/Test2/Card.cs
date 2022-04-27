using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test2
{
    public class Card
    {
        private int _index;
        private int _value;
        private string _cardName;
        private string _description;
        private string _spriteName;

        public Card(int value, string name, string description, string spriteName)
        {
            _index = 0;
            _value = value;
            _cardName = name;
            _description = description;
            _spriteName = spriteName;
        }

        public Card GetThis()
        {
            return new Card(_value, _cardName, _description, _spriteName);
        }

        public int Index { get => _index; }
        public int Value { get => _value; }
        public string Name { get => _cardName; }
        public string Description { get => _description; }
        public string SpriteName { get => _spriteName; }

        public void SetIndex(int index) { _index = index; }
    }
}
