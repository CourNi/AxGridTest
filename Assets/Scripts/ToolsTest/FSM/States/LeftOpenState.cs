using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("LeftOpenState")]
    public class LeftOpenState : ControlState
    {
        [Enter]
        private protected override void OnEnter()
        {
            Model.Set("LCoffinState", true);
            base.OnEnter();
        }
    }
}