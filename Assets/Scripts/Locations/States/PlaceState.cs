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

        public virtual void OnMovement(string location)
        {
            Settings.Model.EventManager.Invoke("Move", location);
            Parent.Change("WalkState");
        }

        public virtual void OnExit(string locationName)
        {
            Debug.Log($"{locationName}Exit");
        } 
    }
}