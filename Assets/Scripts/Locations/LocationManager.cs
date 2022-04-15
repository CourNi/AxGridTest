using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class LocationManager
    {
        private LocationManager() { }

        private readonly List<Location> _locations = new List<Location>();

        public static LocationManager Instance { get; private set; }

        public static void Initialize()
        {
            Instance = new LocationManager();
        }

        public void Add(Location location)
        {
            _locations.Add(location);
        }

        public void Remove(Location location)
        {
            _locations.Remove(location);
        }

        public Vector2 GetLocationPosition(string name)
        {
            return _locations.Where(i => i.Name == name).FirstOrDefault().Position;
        }
    }
}
