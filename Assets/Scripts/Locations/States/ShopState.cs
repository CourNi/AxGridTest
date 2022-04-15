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
        public void OnEnter() => base.OnEnter("Shop", Color.blue);

        [Loop(0.25f)]
        public override void OnLoop()
        {
            if (Settings.Model.GetInt("Balance") > 0) Settings.Model.Dec("Balance");
        }

        [Bind]
        public override void OnMovement(string location) => base.OnMovement(location);

        [Exit]
        public void OnExit() => base.OnExit("Shop");
    }
}
