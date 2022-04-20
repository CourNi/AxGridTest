using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using AxGrid.Base;
using AxGrid.Path;

namespace Test2 {
    public class CardObject : MonoBehaviourExt, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isActive = true;
        private string _targetCollection = "Opponent";
        private Card _card;
        private int _value;
        [SerializeField]
        private TextMeshProUGUI _valueText;
        [SerializeField]
        private TextMeshProUGUI _title;
        [SerializeField]
        private TextMeshProUGUI _description;
        [SerializeField]
        private Image _image;

        #region Mark
        [SerializeField]
        private float _easeTime = 0.2f;
        [SerializeField]
        private float _scaleFactor = 1.15f;
        private Vector3 _currentScale;
        private Vector3 _targetScale;
        private Vector3 _outScale;
        private Vector3 _inScale;
        #endregion

        #region Drag
        private bool _isDragging = false;
        private Vector3 _parentPosition;
        private Vector3 _sourcePosition;
        private Quaternion _sourceRotation;
        private float _canvasScale;
        private float _screenWidth;
        private float _screenHeight;
        #endregion

        [OnStart]
        private void OnStart()
        {
            _canvasScale = UIManager.Instance.MainCanvas.scaleFactor;
            _screenWidth = Screen.width / _canvasScale / 2;
            _screenHeight = Screen.height / _canvasScale / 2;
            _inScale = transform.localScale;
            _outScale = _inScale * _scaleFactor;
            _parentPosition = transform.parent.localPosition;
        }

        [OnUpdate]
        private void OnUpdate()
        {
            if (_isDragging)
            {
                transform.localPosition = (Vector3)ScreenPosition(Mouse.current.position.ReadValue()) - _parentPosition;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isActive)
            {
                Path = new CPath();
                _currentScale = transform.localScale;
                _targetScale = _outScale;

                Path.EasingLinear(_easeTime, 0.0f, 1.0f, value => SetScale(value));
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_isActive)
            {
                Path = new CPath();
                _currentScale = transform.localScale;
                _targetScale = _inScale;

                Path.EasingLinear(_easeTime / 2, 0.0f, 1.0f, value => SetScale(value));
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isActive)
            {
                _sourcePosition = transform.localPosition;
                _sourceRotation = transform.localRotation;
                transform.localRotation = Quaternion.identity;
                _isDragging = true;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_isActive)
            {
                _isDragging = false;
                int currentPool = Model.GetList<Card>($"{_targetCollection}List").Count;
                int poolSize = Model.GetInt($"{_targetCollection}Pool");
                if (transform.localPosition.y > _screenHeight && currentPool < poolSize)
                {
                    Model.EventManager.Invoke("OnCardTransfer", this);
                }
                else
                {
                    transform.localPosition = _sourcePosition;
                    transform.localRotation = _sourceRotation;
                }
            }
        }

        public void SetCard(Card card)
        {
            _card = card;
            _value = card.Value;
            _valueText.text = _value.ToString();
            _title.text = card.Name;
            _description.text = card.Description;
            _image.sprite = Model.Get<Sprite>(card.SpriteName);
        }

        public Card GetCard()
        {
            return _card;
        }

        public void SetTargetCollection(string collectionName)
        {
            _targetCollection = collectionName;
        }

        public void SetActiveState(bool state)
        {
            _isActive = state;
        }

        private void SetScale(float time)
        {
            transform.localScale = Vector3.Lerp(_currentScale, _targetScale, time);
        }

        private Vector2 ScreenPosition(Vector2 pos)
        {
            return new Vector2(pos.x / _canvasScale - _screenWidth, pos.y / _canvasScale - _screenHeight);
        }
    }
}