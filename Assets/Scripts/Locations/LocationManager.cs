using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class LocationManager
    {
        private LocationManager() { }

        private readonly List<Location> _locations = new List<Location>();

        public static LocationManager Current { get; private set; }

        public static void Initialize()
        {
            Current = new LocationManager();
        }

        public void Add<T>(T location) where T : Location
        {
            _locations.Add(location);
        }

        public void Remove<T>(T location) where T : Location
        {
            _locations.Remove(location);
        }

        public Vector2 GetLocationPosition(string name)
        {
            return _locations.Where(i => i.Name == name).FirstOrDefault().Position;
        }
    }
}
