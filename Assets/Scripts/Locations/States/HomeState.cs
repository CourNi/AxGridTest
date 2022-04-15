using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace Test
{
    [State("HomeState")]
    public class HomeState : PlaceState
    {
        [Enter]
        private void OnEnter() => base.OnEnter("Home", Color.grey);

        [Loop(0.25f)]
        private protected override void OnLoop() => base.OnLoop();

        [Bind]
        private protected override void OnBtn(string location) => base.OnBtn(location);

        [Exit]
        private void OnExit() => base.OnExit("Home");
    }
}
