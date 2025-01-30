using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawUpLine : MonoBehaviour
{
    public Vector2 origin;

    public void FixedUpdate()
    {
        this.drawLine(this.origin, this.origin + new Vector2(0, 1));
    }

    private void drawLine(Vector2 start, Vector2 end)
    {
        LineRenderer lr = GetComponentInParent<LineRenderer>();

        Vector3[] points = { start, end };
        lr.SetPositions(points);
    }
}
