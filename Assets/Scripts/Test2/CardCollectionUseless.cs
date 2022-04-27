using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Path;
using AxGrid.Base;
using AxGrid.Model;

namespace Test2 {
    public class CardCollectionUseless : MonoBehaviourExtBind
    {
        [SerializeField]
        private bool _isMainCollection = false;
        [SerializeField]
        private string _collectionName = "";
        private Vector3 _deckPosition;
        private List<Card> _cardList = new List<Card>();
        private List<CardObject> _currentCollection = new List<CardObject>();

        #region Pool
        [SerializeField]
        private CardObject _cardPrefab;
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
            _deckPosition = Model.Get<Vector3>("DeckPosition");
            if (_isMainCollection) _collectionName = "Main";
            Model.Set($"{_collectionName}List", _cardList);
            Model.Set($"{_collectionName}Pool", _poolSize);
            Model.Set($"{_collectionName}Position", transform.position);
            Settings.Fsm.Invoke("OnCollectionCreate", _collectionName);
            Model.EventManager.AddAction($"On{_collectionName}ListChanged", OnCardListChanged);
        }

        [OnDestroy]
        private void Destroy()
        {
            Model.EventManager.RemoveAction($"On{_collectionName}ListChanged", OnCardListChanged);
        }

        [Bind]
        private void OnCardAdd(Card card)
        {
            if (_isMainCollection)
            {
                Path = new CPath();

                CardObject obj = Instantiate(_cardPrefab, _deckPosition, Quaternion.identity, transform);
                obj.SetCard(card);
                Path.EasingLinear(0.25f, 0, 1, value => MoveCard(obj.transform, _deckPosition, transform.position, value))
                    .Action(() => Destroy(obj.gameObject))
                    .Action(() => OnCardListChanged());
            }
        }

        private void OnCardListChanged()
        {
            int elements = _cardList.Count;
            float startAngle = _angle * (elements - 1) * -1;

            _currentCollection.ForEach(i => Destroy(i.gameObject));
            _currentCollection.Clear();
            _cardList.ForEach(i =>
            {
                float angle = startAngle + _step * (elements - 1);
                var cardObj = Instantiate(_cardPrefab, transform);
                cardObj.transform.localPosition = new Vector2(0, _radius * -1) + GetPositionByAngle(angle * 3 - 270);
                cardObj.transform.localRotation = Quaternion.Euler(0, 0, angle);
                _currentCollection.Add(cardObj);
                cardObj.SetCard(i);
                elements--;
            });
        }

        private void MoveCard(Transform cardTransform, Vector3 fromPosition, Vector3 toPosition, float step)
        {
            cardTransform.position = Vector3.Lerp(fromPosition, toPosition, step);
        }

        private Vector2 GetPositionByAngle(float angle)
        {
            return new Vector2(_radius * Mathf.Cos(Mathf.Deg2Rad * angle), _radius * Mathf.Sin(Mathf.Deg2Rad * angle));
        }
    }
}
