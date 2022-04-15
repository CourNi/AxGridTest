using UnityEngine;
using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;

namespace Test
{
    [State("WalkState")]
    public class WalkState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            string targetLocation = Settings.Model.GetString("State");
            Settings.Model.EventManager.Invoke("Move", targetLocation);
            Debug.Log("MovementEnter");
        }

        [Bind]
        private void OnMovementEnd()
        {
            string stateName = Settings.Model.GetString("State");
            Parent.Change($"{stateName}State");
        }

        [Bind]
        public void OnBtn(string location)
        {
            GeneralActions.ChangeLocationState(location);
            Settings.Model.EventManager.Invoke("Move", location);
        }

        [Exit]
        private void OnExit()
        {
            Debug.Log("MovementExit");
        }
    }
}