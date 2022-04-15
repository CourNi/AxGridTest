using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;

namespace Test
{
    public class FSMMain : MonoBehaviourExtBind
    {
        [SerializeField]
        private Movement _workerMovement;

        [OnAwake]
        private void ManagersInitialize()
        {
            LocationManager.Initialize();
        }

        [OnStart]
        private void Initialize()
        {
            Settings.Model.Set("Balance", 0);
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new HomeState());
            Settings.Fsm.Add(new WorkState());
            Settings.Fsm.Add(new ShopState());
            Settings.Fsm.Add(new WalkState());

            Settings.Fsm.Start("HomeState");
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
    }
}
