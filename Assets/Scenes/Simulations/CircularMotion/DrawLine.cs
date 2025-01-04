using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject COR = GameObject.Find("CentreOfRotation");
        GameObject body = GameObject.Find("Body");
        LineRenderer lr = GetComponentInChildren<LineRenderer>();

        Vector3[] positions = { COR.transform.position, body.transform.position };
        lr.SetPositions(positions);
    }
}
