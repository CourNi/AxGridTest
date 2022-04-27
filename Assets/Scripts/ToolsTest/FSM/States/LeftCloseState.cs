using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("LeftCloseState")]
    public class LeftCloseState : ControlState
    {
        protected override string FieldGrave => "LCoffinState";
        protected override bool State => false;
    }
}
