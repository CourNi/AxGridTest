using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace ToolsTest
{
    public abstract class ControlState : FSMState
    {
        protected abstract string FieldGrave { get; }
        protected abstract bool State { get; }

        [Enter]
        protected virtual void OnEnter()
        {
            Model.Set(FieldGrave, State);
            Parent.Change("ListenerState");
        }

        [Exit]
        protected virtual void OnExit()
        {
            Debug.Log("Done");
        }
    }
}