using UnityEngine;
using AxGrid.FSM;
using AxGrid;
using AxGrid.Model;

namespace Test
{
    [State("HomeState")]
    public class HomeState : PlaceState
    {
        [Enter]
        public void OnEnter() => base.OnEnter("Home", Color.grey);

        [Loop(0.25f)]
        public override void OnLoop() => base.OnLoop();

        [Bind]
        public override void OnBtn(string location) => base.OnBtn(location);

        [Exit]
        public void OnExit() => base.OnExit("Home");
    }
}
