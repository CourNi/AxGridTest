using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace ToolsTest
{
    [State("ListenerState")]
    public class ListenerState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Debug.Log("Listen");
        }

        [Bind]
        private void OnLeftCoffinStateChanged(bool state)
        {
            if (state) Parent.Change("LeftOpenState");
            else Parent.Change("LeftCloseState");
        }

        [Bind]
        private void OnRightCoffinStateChanged(bool state)
        {
            if (state) Parent.Change("RightOpenState");
            else Parent.Change("RightCloseState");
        }

        [Bind]
        private void OnGameOver()
        {
            Parent.Change("OverState");
        }

        [Exit]
        private void OnExit()
        {
            Debug.Log("Action");
        }
    }
}
