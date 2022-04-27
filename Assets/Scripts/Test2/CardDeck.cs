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
        [SerializeField]
        private CardObject _cardObjectPrefab;
        private List<Card> _cardPool = new List<Card>();
        private List<CardObject> _cardObjectPool = new List<CardObject>();
        private Outline _outline;
        private int _poolSize;

        [OnAwake]
        private void OnAwake()
        {
            Model.Set("DeckPosition", transform.position);
            Model.Set("DeckPool", _cardObjectPool);
            _outline = GetComponent<Outline>();

            _cardPool.Add(new Card(2, "Coin", "Add some coins", "coin"));
            _cardPool.Add(new Card(4, "Pouch", "Give 2-4 coin cards", "pouch"));
            _cardPool.Add(new Card(8, "Ring", "Add random magic", "ring"));
            _cardPool.Add(new Card(5, "Cauldron", "Make random potion", "cauldron"));
            _poolSize = _cardPool.Count;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Model.GetList<Card>("MainList").Count < Model.GetInt("MainPool"))
            {
                var cardObj = Instantiate(_cardObjectPrefab, transform);
                Model.GetList<CardObject>("DeckPool").Add(cardObj);
                Settings.Fsm.Invoke("OnDeckClick", _cardPool[Random.Range(0, _poolSize)].GetThis());
            }
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