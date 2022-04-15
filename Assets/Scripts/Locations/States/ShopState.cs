using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid;

namespace Test
{
    [State("ShopState")]
    public class ShopState : PlaceState
    {
        [Enter]
        private void OnEnter() => base.OnEnter("Shop", Color.blue);

        [Loop(0.25f)]
        private protected override void OnLoop()
        {
            if (Settings.Model.GetInt("Balance") > 0) Settings.Model.Dec("Balance");
        }

        [Bind]
        private protected override void OnBtn(string location) => base.OnBtn(location);

        [Exit]
        private void OnExit() => base.OnExit("Shop");
    }
}
