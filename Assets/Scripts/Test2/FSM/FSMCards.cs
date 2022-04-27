using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;

namespace Test2
{
    public class FSMCards : MonoBehaviourExt
    {
        [OnAwake]
        private void OnAwake()
        {
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new ReadyState());

            Settings.Fsm.Start("InitState");
        }

        [OnUpdate]
        private void OnUpdate()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
    }
}
