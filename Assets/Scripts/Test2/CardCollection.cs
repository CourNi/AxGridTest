using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.Model;

namespace Test2 {
    public class CardCollection : MonoBehaviourExtBind
    {
        [SerializeField]
        private bool _isPlayerHand = false;
        [SerializeField]
        private string _collectionName = "";
        private List<Card> _cardList = new List<Card>();

        #region Pool
        [SerializeField]
        private CardObject _cardPrefab;
        private Queue<CardObject> _cardPool = new Queue<CardObject>();
        [SerializeField]
        private int _poolSize;
        #endregion

        #region HandArc
        [SerializeField]
        private float _angle = 3.0f;
        [SerializeField]
        private float _radius;
        private float _step;
        #endregion

        [OnStart]
        private void OnStart()
        {
            _step = _angle * 2;
            Model.Set($"{_collectionName}List", _cardList);
            Model.Set($"{_collectionName}Pool", _poolSize);

            for (int i = 0; i < _poolSize; i++)
            {
                CardObject obj = Instantiate(_cardPrefab, transform.position, Quaternion.identity, transform);
                if (!_isPlayerHand) obj.SetActiveState(false);
                obj.gameObject.SetActive(false);
                _cardPool.Enqueue(obj);
            }
        }

        private void OnCardListChanged()
        {
            int elements = _cardList.Count;
            float startAngle = _angle * (elements - 1) * -1;
            foreach (Transform child in transform)
            {
                if (elements == 0) return;
                if (child.gameObject.activeSelf)
                {
                    float angle = startAngle + _step * (elements - 1);
                    child.localPosition = new Vector2(0, _radius * -1) + GetPositionByAngle(angle * 3 - 270);
                    child.localRotation = Quaternion.Euler(0, 0, angle);
                    elements -= 1;
                }
            }
        }

        private Vector2 GetPositionByAngle(float angle)
        {
            return new Vector2(_radius * Mathf.Cos(Mathf.Deg2Rad * angle), _radius * Mathf.Sin(Mathf.Deg2Rad * angle));
        }

        [Bind]
        private void OnDeckClick(Card card)
        {
            if (_isPlayerHand) Add(card);
        }

        private void Add(Card card)
        {
            if (_cardList.Count < _poolSize)
            {
                var cardToAdd = _cardPool.Dequeue();
                cardToAdd.SetCard(card);
                cardToAdd.gameObject.SetActive(true);
                _cardList.Add(card);
                OnCardListChanged();
            }
        }

        [Bind]
        private void OnCardTransfer(CardObject cardObj)
        {
            if (_isPlayerHand)
            {
                _cardList.Remove(cardObj.GetCard());
                _cardPool.Enqueue(cardObj);
                cardObj.gameObject.SetActive(false);
                OnCardListChanged();
            }
            else
            {
                Add(cardObj.GetCard());
            }
        }
    }
}
