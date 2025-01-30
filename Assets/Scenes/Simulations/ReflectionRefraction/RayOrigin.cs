using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    }

    private void drawDirectionVector()
    {
        Vector2 up = new float2(0, 1);

        // Rotate by angle
        // See https://docs.unity3d.com/Packages/com.unity.mathematics@1.3/manual/4x4-matrices.html
        float cosAngle = math.cos(math.PI - this.angle);
        float sinAngle = math.sin(math.PI - this.angle);
        float2x2 rotationMatrix = math.float2x2(cosAngle, -sinAngle, sinAngle, cosAngle);

        up = math.mul(rotationMatrix, up);

        Debug.Log($"Direction vector: ({up.x}, {up.y})");
    }
}
