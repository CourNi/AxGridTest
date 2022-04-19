using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace ToolsTest
{
    [State("BeginState")]
    public class BeginState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Model.Set("UIState", false);
        }

        [Bind]
        private void OnGameStart()
        {
            Parent.Change("ListenerState");
        }

        [Exit]
        private void OnExit()
        {
            Model.Set("UIState", true);
        }
    }
}