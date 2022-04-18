using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace AxGrid.Tools.Binders
{
    [RequireComponent(typeof(Toggle))]
    public class UIToggleTool : Binder
    {
        private Toggle toggle;

        [SerializeField]
        private string toggleName = "";
        
        [OnAwake]
        private void OnAwake()
        {
            if (string.IsNullOrEmpty(toggleName)) toggleName = name;

            toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool toggleState)
        {
            Model?.EventManager.Invoke($"On{toggleName}StateChange", toggleState);
            Settings.Fsm?.Invoke($"On{toggleName}StateChange", toggleState);
        }

        [OnDestroy]
        private void Destroy()
        {
            toggle.onValueChanged.RemoveAllListeners();
        }
    }
}
