using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

namespace AxGrid.Tools.Binders
{
    public class GOListToggleTool : Binder
    {
        [SerializeField]
        private string objectName = "";
        private string objectStateName = "";
        [SerializeField]
        private bool defaultEnable = true;
        [SerializeField]
        private List<GameObject> _objectsList = new List<GameObject>();
        [SerializeField]
        private List<GameObject> _invertedObjectsList = new List<GameObject>();

        [OnAwake]
        private void OnAwake()
        {
            if (string.IsNullOrEmpty(objectName)) objectName = name;
            objectStateName = $"{objectName}State";
        }

        [OnStart]
        private void OnStart()
        {
            Model.EventManager.AddAction($"On{objectStateName}Changed", OnToggleStateChange);
            Model.Set(objectStateName, defaultEnable);
        }

        private void OnToggleStateChange()
        {
            bool state = Model.GetBool(objectStateName);

            _objectsList.ForEach(obj => obj.SetActive(state));
            _invertedObjectsList.ForEach(obj => obj.SetActive(!state));
        }

        [OnDestroy]
        private void Destroy()
        {
            Model.EventManager.RemoveAction($"On{objectStateName}Changed", OnToggleStateChange);
        }
    }
}
