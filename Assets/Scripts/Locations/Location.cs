using UnityEngine;
using AxGrid.Base;

namespace Test {
    public class Location : MonoBehaviourExt
    {
        [SerializeField]
        private string _locationName;
        private Vector2 _position;

        [OnAwake]
        private void Initialize()
        {
            _position = transform.localPosition;
            LocationManager.Current.Add(this);
        }

        public string Name { get => _locationName; }
        public Vector2 Position { get => _position; }
    }
}
