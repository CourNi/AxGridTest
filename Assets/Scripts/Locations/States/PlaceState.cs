using UnityEngine;
using AxGrid.FSM;
using AxGrid;

namespace Test
{
    public abstract class PlaceState : FSMState
    {
        private protected virtual void OnEnter(string locationName, Color color)
        {
            Debug.Log($"{locationName}Enter");
            Settings.Model.EventManager.Invoke("BackgroundChange", color);
        }

        private protected virtual void OnLoop()
        {
            Debug.Log("Idle");
        }

        private protected virtual void OnBtn(string location)
        {
            GeneralActions.ChangeLocationState(location);
            Parent.Change("WalkState");
        }

        private protected virtual void OnExit(string locationName)
        {
            Debug.Log($"{locationName}Exit");
        } 
    }
}