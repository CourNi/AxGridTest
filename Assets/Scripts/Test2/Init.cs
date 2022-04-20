using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid.Base;

namespace Test2
{
    public class Init : MonoBehaviourExt
    {
        [SerializeField]
        private List<Sprite> _sprites;

        [OnAwake]
        private void OnAwake()
        {
            foreach (Sprite sprite in _sprites)
            {
                Model.Set(sprite.name, sprite);
            }
        }
    }
}