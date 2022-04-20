using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AxGrid.Base;

public class UIManager : MonoBehaviourExt
{
    #region Singleton
    public static UIManager Instance;

    [OnAwake]
    private void OnAwake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    private Canvas _canvas;

    public Canvas MainCanvas { get => _canvas; }
}
