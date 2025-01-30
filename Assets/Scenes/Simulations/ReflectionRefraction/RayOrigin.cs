using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RayOrigin : MonoBehaviour
{
    public Vector2 origin;
    private Vector2 direction;
    public float angle;

    public void Start()
    {
        
    }

    public void FixedUpdate()
    {
        // Debug
        this.drawDirectionVector();
        drawUpLine drawUp = GetComponentInChildren<drawUpLine>();
        drawUp.origin = this.origin;
    }

    private void drawDirectionVector()
    {
        Vector2 directionVector = getDirectionVector();

        Debug.Log($"Direction vector: ({directionVector.x}, {directionVector.y})");

        // Debug, draw vector
        drawLine(this.origin, this.origin + directionVector);
    }

    private Vector2 getDirectionVector()
    {
        Vector2 up = new float2(0, 1);

        // Rotate by angle
        // See https://docs.unity3d.com/Packages/com.unity.mathematics@1.3/manual/4x4-matrices.html
        float cosAngle = math.cos((2 * math.PI) - math.radians(this.angle));
        float sinAngle = math.sin((2 * math.PI) - math.radians(this.angle));
        float2x2 rotationMatrix = math.float2x2(cosAngle, -sinAngle, sinAngle, cosAngle);

        return math.mul(rotationMatrix, up);
    }

    private void drawLine(Vector2 start, Vector2 end)
    {
        LineRenderer lr = GetComponentInParent<LineRenderer>();

        Vector3[] points = { start, end };
        lr.SetPositions(points);
    }
}
