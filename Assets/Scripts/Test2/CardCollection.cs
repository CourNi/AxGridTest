using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Path;
using AxGrid.Base;
using AxGrid.Model;

namespace Test2
{
    public class CardCollection : MonoBehaviourExtBind
    {
        private const float CorrectionAngle = 270;
        private const float PositionAngleMultiplier = 3;

        [SerializeField]
        private bool _isMainCollection = false;
        [SerializeField]
        private string _collectionName = "";
        private List<Card> _cardList = new List<Card>();
        private List<CardObject> _currentCollection = new List<CardObject>();

        [SerializeField]
        private int _poolSize;
        private float _animationTime = 0.25f;

        #region CardArc
        [Header("Card Arc")]
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

            if (_isMainCollection) _collectionName = "Main";
            Model.Set($"{_collectionName}List", _cardList);
            Model.Set($"{_collectionName}Pool", _poolSize);
            Model.Set($"{_collectionName}Position", transform.position);
            Settings.Fsm.Invoke("OnCollectionCreate", _collectionName);
            Model.EventManager.AddAction($"On{_collectionName}ListChanged", OnCardListChanged);
            Model.EventManager.AddAction($"On{_collectionName}MoveEnd", Rearrange);
        }
        
        private void OnCardListChanged()
        {
            var indexesCollection = _currentCollection.Select(x => x.GetCard().Index);
            var indexesList = _cardList.Select(x => x.Index);

            if (indexesList.Count() > indexesCollection.Count())
            {
                var indexCardToAdd = indexesList.Where(i => !indexesCollection.Contains(i)).FirstOrDefault();
                var card = _cardList.Where(i => i.Index == indexCardToAdd).FirstOrDefault();
                var cardToAddExisted = Model.GetList<CardObject>("DeckPool").Where(i => i.GetCard() == card).FirstOrDefault();
                try
                {
                    AddCardObject(cardToAddExisted);
                }
                catch (NullReferenceException e)
                {
                    var cardToAddNew = _cardList.Where(i => i.Index == indexCardToAdd).FirstOrDefault();
                    AddCard(cardToAddNew);
                }
            }
            else if (indexesList.Count() < indexesCollection.Count())
            {
                var indexCardToRemove = indexesCollection.Where(i => !indexesList.Contains(i)).FirstOrDefault();
                var cardToRemove = _currentCollection.Where(i => i.GetCard().Index == indexCardToRemove).FirstOrDefault();
                RemoveCard(cardToRemove);
            }
            else throw new Exception("Incorrect indexes");
        }

        private void AddCardObject(CardObject cardObj)
        {
            cardObj.transform.SetParent(transform);
            cardObj.MoveCard(_collectionName);
            _currentCollection.Add(cardObj);
        }

        private void AddCard(Card card)
        {
            var cardObj = Model.GetList<CardObject>("DeckPool").Last();
            cardObj.SetCard(card);
            AddCardObject(cardObj);
        }

        private void RemoveCard(CardObject cardObj)
        {
            _currentCollection.Remove(cardObj);
            Rearrange();
        }

        private void Rearrange()
        {
            int elements = _currentCollection.Count;
            float startAngle = _angle * (elements - 1) * -1;

            _currentCollection.ForEach(i =>
            {
                float angle = startAngle + _step * (elements - 1);
                i.transform.localPosition = new Vector2(0, _radius * -1) + GetPositionByAngle(angle * PositionAngleMultiplier - CorrectionAngle);
                i.transform.localRotation = Quaternion.Euler(0, 0, angle);
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

        [OnDestroy]
        private void Destroy()
        {
            Model.EventManager.RemoveAction($"On{_collectionName}ListChanged", OnCardListChanged);
            Model.EventManager.RemoveAction($"On{_collectionName}MoveEnd", Rearrange);
        }
    }
}