using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("RightOpenState")]
    public class RightOpenState : ControlState
    {
        [Enter]
        private protected override void OnEnter()
        {
            Model.Set("RCoffinState", true);
            base.OnEnter();
        }
    }
}
