using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using AxGrid.Base;
using AxGrid;

namespace Test2 {
    public class CardDeck : MonoBehaviourExt, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private List<Card> _cardPool;
        private Outline _outline;
        private int _poolSize;

        [OnAwake]
        private void OnAwake()
        {
            _outline = GetComponent<Outline>();

            _cardPool = new List<Card>();
            _cardPool.Add(new Card(2, "Coin", "Add some coins", "coin"));
            _cardPool.Add(new Card(4, "Pouch", "Give 2-4 coin cards", "pouch"));
            _cardPool.Add(new Card(8, "Ring", "Add random magic", "ring"));
            _cardPool.Add(new Card(5, "Cauldron", "Make random potion", "cauldron"));
            _poolSize = _cardPool.Count;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Model.EventManager.Invoke("OnDeckClick", _cardPool[Random.Range(0, _poolSize)]);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _outline.enabled = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _outline.enabled = false;
        }
    }
}