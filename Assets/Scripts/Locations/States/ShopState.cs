using UnityEngine;
using AxGrid.FSM;
using AxGrid;

namespace Test
{
    [State("ShopState")]
    public class ShopState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Settings.Model.ToggleBool("BtnShopEnable", true);
            Settings.Model.EventManager.Invoke("Move", "Shop");
            Settings.Model.EventManager.Invoke("BackgroundChange", Color.blue);
        }

        [Loop(0.25f)]
        private void OnLoop()
        {
            if (!Settings.Model.GetBool("Moving") && Settings.Model.GetInt("Balance") > 0) Settings.Model.Dec("Balance");
        }

        [Exit]
        private void OnExit()
        {
            Settings.Model.ToggleBool("BtnShopEnable", false);
        }
    }
}
