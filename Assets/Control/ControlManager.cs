using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Base;

public class ControlManager : MonoBehaviourExt
{
    #region Singleton
    public static ControlManager Instance;

    void Awake()
    {
        Instance = this;
    }
    #endregion

    private MainControl _control;

    public MainControl Control { get => _control; }

    [OnAwake]
    private void OnAwake()
    {
        _control = new MainControl();
    }
}
