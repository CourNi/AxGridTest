using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using AxGrid;
using AxGrid.Base;
using AxGrid.Path;
using AxGrid.Model;

namespace Test2 {
    public class CardObject : MonoBehaviourExtBind, IPointerDownHandler
    {
        private string _targetCollection = "";
        private Card _card;
        [SerializeField]
        private TextMeshProUGUI _valueText;
        [SerializeField]
        private TextMeshProUGUI _title;
        [SerializeField]
        private TextMeshProUGUI _description;
        [SerializeField]
        private Image _image;

        private bool _isClickable = false;
        private Vector3 _currentPosition;
        private Vector3 _targetPosition;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isClickable) Settings.Fsm.Invoke("OnCardClick", _targetCollection, _card.Index);
        }

        public void MoveCard(string targetCollection)
        {
            Path = new CPath();

            _isClickable = false;
            _targetCollection = targetCollection;
            _currentPosition = transform.position;
            _targetPosition = Model.Get<Vector3>($"{_targetCollection}Position");

            Path.EasingLinear(0.25f, 0, 1, value => MoveToPosition(value))
                .Action(() => Model.EventManager.Invoke($"On{_targetCollection}MoveEnd"))
                .Action(() => _isClickable = true);
        }

        public void SetCard(Card card)
        {
            _card = card;
            _valueText.text = card.Value.ToString();
            _title.text = card.Name;
            _description.text = card.Description;
            _image.sprite = Model.Get<Sprite>(card.SpriteName);
        }

        public Card GetCard()
        {
            return _card;
        }

        private void MoveToPosition(float step)
        {
            transform.position = Vector3.Lerp(_currentPosition, _targetPosition, step);
        }
    }
}