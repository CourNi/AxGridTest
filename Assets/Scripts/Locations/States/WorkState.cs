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
        private void OnEnter() => base.OnEnter("Work", Color.red);

        [Loop(0.25f)]
        private protected override void OnLoop()
        {
            Settings.Model.Inc("Balance");
        }

        [Bind]
        private protected override void OnBtn(string location) => base.OnBtn(location);

        [Exit]
        private void OnExit() => base.OnExit("Work");
    }
}
