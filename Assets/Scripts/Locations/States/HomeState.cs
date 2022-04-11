using UnityEngine;
using AxGrid.FSM;
using AxGrid;

namespace Test
{
    [State("HomeState")]
    public class HomeState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Settings.Model.Set("BtnHomeEnable", false);
            Settings.Model.EventManager.Invoke("Move", "Home");
            Settings.Model.EventManager.Invoke("BackgroundChange", Color.grey);
        }

        [Exit]
        private void OnExit()
        {
            Settings.Model.Set("BtnHomeEnable", true);
        }
    }
}
