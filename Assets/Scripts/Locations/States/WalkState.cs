using System.Collections;
using System.Collections.Generic;
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
            string currentLocation = Settings.Model.GetString("State");
            Settings.Model.Set($"Btn{currentLocation}Enable", true);
            Settings.Model.Set($"Btn{location}Enable", false);
            Settings.Model.Set("State", location);
            Settings.Model.EventManager.Invoke("Move", location);
        }

        [Exit]
        private void OnExit()
        {
            Debug.Log("MovementExit");
        }
    }
}