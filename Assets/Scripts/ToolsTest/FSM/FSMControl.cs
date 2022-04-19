using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;

namespace ToolsTest
{
    public class FSMControl : MonoBehaviourExtBind
    {
        [OnStart]
        private void Initialize()
        {
            Settings.Model.Set("Score", 0);
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new BeginState());
            Settings.Fsm.Add(new ListenerState());
            Settings.Fsm.Add(new LeftOpenState());
            Settings.Fsm.Add(new RightOpenState());
            Settings.Fsm.Add(new LeftCloseState());
            Settings.Fsm.Add(new RightCloseState());
            Settings.Fsm.Add(new OverState());

            Settings.Fsm.Start("BeginState");
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
    }
}