using UnityEngine;
using AxGrid.FSM;
using AxGrid;

namespace Test
{
    [State("WorkState")]
    public class WorkState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Settings.Model.ToggleBool("BtnWorkEnable", true);
            Settings.Model.EventManager.Invoke("Move", "Work");
            Settings.Model.EventManager.Invoke("BackgroundChange", Color.red);
        }

        [Loop(0.25f)]
        private void OnLoop()
        {
            if (!Settings.Model.GetBool("Moving")) Settings.Model.Inc("Balance");
        }

        [Exit]
        private void OnExit()
        {
            Settings.Model.ToggleBool("BtnWorkEnable", false);
        }
    }
}
