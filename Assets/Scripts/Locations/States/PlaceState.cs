using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid;

namespace Test
{
    public abstract class PlaceState : FSMState
    {
        public virtual void OnEnter(string locationName, Color color)
        {
            Debug.Log($"{locationName}Enter");
            Settings.Model.EventManager.Invoke("Move", locationName);
            Settings.Model.EventManager.Invoke("BackgroundChange", color);
        }

        public virtual void OnLoop()
        {
            Debug.Log("Idle");
        }

        public virtual void OnBtn(string location)
        {
            string currentLocation = Settings.Model.GetString("State");
            Settings.Model.Set($"Btn{currentLocation}Enable", true);
            Settings.Model.Set($"Btn{location}Enable", false);
            Settings.Model.Set("State", location);
            Settings.Model.EventManager.Invoke("Move", location);
            Parent.Change("WalkState");
        }

        public virtual void OnExit(string locationName)
        {
            Debug.Log($"{locationName}Exit");
        } 
    }
}