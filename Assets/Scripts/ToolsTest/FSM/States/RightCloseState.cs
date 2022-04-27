using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("RightCloseState")]
    public class RightCloseState : ControlState
    {
        protected override string FieldGrave => "RCoffinState";
        protected override bool State => false;
    }
}
