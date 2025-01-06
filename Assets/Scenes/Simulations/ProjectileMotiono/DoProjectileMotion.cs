using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoProjectileMotion : MonoBehaviour
{
    public float mass;
    public float velocity;
    public float gravitationalAcceleration;
    public float angleOfProjection;
    public float timeSinceLaunch = 0f;
    public Vector2 velocityVector;
    public Vector2 displacement = new Vector2(0, 0);
}
