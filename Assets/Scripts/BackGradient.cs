using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode] 
[RequireComponent(typeof(CanvasRenderer))]
public class BackGradient : Graphic
{
    private enum GradientType
    {
        LeftToRight, RightToLeft, TopDown, DownTop
    }

    [SerializeField] private GradientType type;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        var pivot = rectTransform.pivot;
        var rect = rectTransform.rect;

        var corner1 = new Vector2(-pivot.x * rect.width, -pivot.y * rect.height);
        var corner2 = new Vector2((1 - pivot.x) * rect.width, (1 - pivot.y) * rect.height);
        
        vh.Clear();

        var vert = UIVertex.simpleVert;
        
        AddVertex(ref vert, ref vh, corner1.x, corner1.y, type == GradientType.RightToLeft || type == GradientType.TopDown);
        AddVertex(ref vert, ref vh, corner1.x, corner2.y, type == GradientType.RightToLeft || type == GradientType.DownTop);
        AddVertex(ref vert, ref vh, corner2.x, corner2.y, type == GradientType.LeftToRight || type == GradientType.DownTop);
        AddVertex(ref vert, ref vh, corner2.x, corner1.y, type == GradientType.LeftToRight || type == GradientType.TopDown);

        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);
    }

    private void AddVertex(ref UIVertex uiVertex, ref VertexHelper vh, float x, float y, bool zeroAlpha)
    {
        uiVertex.position = new Vector3(x, y);
        uiVertex.color = color;

        if (zeroAlpha)
        {
            uiVertex.color.a = 0;
        }
        
        vh.AddVert(uiVertex);
    }
}