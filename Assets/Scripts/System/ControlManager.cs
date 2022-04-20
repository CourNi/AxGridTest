using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid;
using AxGrid.Base;

public class ControlManager : MonoBehaviourExt
{
    #region Singleton
    public static ControlManager Instance;

    [OnAwake]
    private void OnAwake()
    {
        Instance = this;
        _control = new MainControl();
    }
    #endregion

    private MainControl _control;

    public MainControl Control { get => _control; }
}
