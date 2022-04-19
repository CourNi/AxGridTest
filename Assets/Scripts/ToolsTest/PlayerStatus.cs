using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Base;
using AxGrid.Model;

public class PlayerStatus : MonoBehaviourExtBind
{
    [OnStart]
    private void OnStart()
    {
        Model.Set("Health", 3);
    }

    [Bind]
    private void OnHealthChanged(int hp)
    {
        if (hp <= 0)
        {
            Model.EventManager.Invoke("OnGameOver");
            Settings.Fsm.Invoke("OnGameOver");
        }
    }
}
