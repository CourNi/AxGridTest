using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("LeftCloseState")]
    public class LeftCloseState : ControlState
    {
        [Enter]
        private protected override void OnEnter()
        {
            Model.Set("LCoffinState", false);
            base.OnEnter();
        }
    }
}
