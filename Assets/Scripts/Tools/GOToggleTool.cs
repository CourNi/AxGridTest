using AxGrid.Base;
using UnityEngine;

namespace AxGrid.Tools.Binders
{
    public class GOToggleTool : Binder
    {
        [SerializeField]
        private string objectName = "";
        [SerializeField]
        private bool defaultEnable = true;

        [OnAwake]
        private void OnAwake()
        {
            if (string.IsNullOrEmpty(objectName)) objectName = name;
            Model.Set($"{objectName}State", defaultEnable);
        }

        [OnStart]
        private void OnStart()
        {
            if (!defaultEnable) gameObject.SetActive(false);
            Model.EventManager.AddAction($"On{objectName}StateChanged", OnToggleStateChange);
        }

        private void OnToggleStateChange()
        {
            bool state = Model.GetBool($"{objectName}State");
            gameObject.SetActive(state);
        }

        [OnDestroy]
        private void Destroy()
        {
            Model.EventManager.RemoveAction($"On{objectName}StateChanged", OnToggleStateChange);
        }
    }
}
