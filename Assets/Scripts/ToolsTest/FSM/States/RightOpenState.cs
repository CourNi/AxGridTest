using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("RightOpenState")]
    public class RightOpenState : ControlState
    {
        protected override string FieldGrave => "RCoffinState";
        protected override bool State => true;
    }
}
