using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector2 ScreenPointAtCanvasSize(Vector2 pos, Canvas canv)
    {
        return new Vector2(pos.x / canv.scaleFactor - Screen.width / canv.scaleFactor / 2, pos.y / canv.scaleFactor - Screen.height / canv.scaleFactor / 2);
    }
}
