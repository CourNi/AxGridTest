using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;

namespace ToolsTest
{
    [State("OverState")]
    public class OverState : FSMState
    {
        [Enter]
        private void OnEnter()
        {
            Debug.Log("Game Over");
        }

        [Exit]
        private void OnExit()
        {
            Debug.Log("Exit");
        }
    }
}
