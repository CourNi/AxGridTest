using UnityEngine;
using AxGrid.FSM;

namespace ToolsTest
{
    [State("LeftOpenState")]
    public class LeftOpenState : ControlState
    {
        protected override string FieldGrave => "LCoffinState";
        protected override bool State => true;
    }
}