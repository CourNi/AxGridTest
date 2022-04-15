using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid;

namespace Test
{
    [State("WorkState")]
    public class WorkState : PlaceState
    {
        [Enter]
        public void OnEnter() => base.OnEnter("Work", Color.red);

        [Loop(0.25f)]
        public override void OnLoop()
        {
            Settings.Model.Inc("Balance");
        }

        [Bind]
        public override void OnMovement(string location) => base.OnMovement(location);

        [Exit]
        public void OnExit() => base.OnExit("Work");
    }
}
