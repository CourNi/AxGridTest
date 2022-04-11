using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.Path;
using AxGrid.Model;

namespace Test
{
    public class Movement : MonoBehaviourExtBind
    {
        [SerializeField]
        private float _animationTime = 1.0f;
        private Vector2 _currentPosition;
        private Vector2 _targetPosition;

        [OnStart]
        private void StartPosition()
        {
            transform.localPosition = LocationManager.Current.GetLocationPosition("Home");
            _currentPosition = transform.localPosition;
        }

        [Bind]
        private void Move(string locationName)
        {
            Path = new CPath();
            _currentPosition = transform.localPosition;
            _targetPosition = LocationManager.Current.GetLocationPosition(locationName);

            Path.EasingLinear(_animationTime, 0.0f, 1.0f, value => MoveToPosition(value))
                .Action(() => Settings.Model.EventManager.Invoke("OnMovementEnd"));
        }

        private void MoveToPosition(float time)
        {
            transform.localPosition = Vector2.Lerp(_currentPosition, _targetPosition, time);
        }
    }
}
