using UnityEngine;
using AxGrid.Base;
using AxGrid.Model;

public class Background : MonoBehaviourExtBind
{
    private Camera _gameCamera;
    
    [OnAwake]
    private void Initialize()
    {
        _gameCamera = Camera.main;
        _gameCamera.backgroundColor = Color.grey;
    }

    [Bind]
    private void BackgroundChange(Color color)
    {
        _gameCamera.backgroundColor = color;
    }
}
