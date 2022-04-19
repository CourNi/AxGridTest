using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("RightCloseState")]
    public class RightCloseState : ControlState
    {
        [Enter]
        private protected override void OnEnter()
        {
            Model.Set("RCoffinState", false);
            base.OnEnter();
        }
    }
}
