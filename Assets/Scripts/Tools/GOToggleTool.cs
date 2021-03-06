using AxGrid.Base;
using UnityEngine;

namespace AxGrid.Tools.Binders
{
    public class GOToggleTool : Binder
    {
        [SerializeField]
        private string objectName = "";
        private string objectStateName = "";
        [SerializeField]
        private bool defaultEnable = true;

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
            gameObject.SetActive(state);
        }

        [OnDestroy]
        private void Destroy()
        {
            Model.EventManager.RemoveAction($"On{objectStateName}Changed", OnToggleStateChange);
        }
    }
}
