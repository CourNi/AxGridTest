using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid.Base;
using AxGrid.FSM;

namespace Test2
{
    [State("InitState")]
    public class InitState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Debug.Log("Init FSM");
            Model.Set("CardIndex", 0);
            Model.Set("CollectionList", new List<string>());
            Parent.Change("ReadyState");
        }

        [Exit]
        private void OnExit()
        {
            Debug.Log("Initialized");
        }
    }
}