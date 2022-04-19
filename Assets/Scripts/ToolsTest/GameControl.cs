using AxGrid.Base;
using AxGrid;

namespace ToolsTest
{
    public class GameControl : MonoBehaviourExt
    {
        private MainControl _control;

        [OnStart]
        void OnStart()
        {
            _control = ControlManager.Instance.Control;
            _control.Main.Begin.performed += ctx => GameBegin();
            _control.Main.Begin.Enable();
        }

        private void GameBegin()
        {
            Settings.Fsm.Invoke("OnGameStart");
            Model.EventManager.Invoke("OnGameStart");
            _control.Main.Begin.Disable();
        }
    }
}