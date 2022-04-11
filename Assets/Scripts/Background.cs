using UnityEngine;
using AxGrid.Base;
using AxGrid.Model;

public class Background : MonoBehaviourExtBind
{
    private Camera _gameCamera;
    
    [OnStart]
    private void Initialize()
    {
        _gameCamera = Camera.main;
    }

    [Bind]
    private void BackgroundChange(Color color)
    {
        _gameCamera.backgroundColor = color;
    }
}
