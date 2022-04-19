using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace ToolsTest
{
    [State("ControlState")]
    public abstract class ControlState : FSMState
    {
        [Enter]
        private protected virtual void OnEnter()
        {
            Parent.Change("ListenerState");
        }

        [Exit]
        private protected virtual void OnExit()
        {
            Debug.Log("Done");
        }
    }
}