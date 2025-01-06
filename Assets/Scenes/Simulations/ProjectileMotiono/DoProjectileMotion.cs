using System;
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

    private void Start()
    {
        // Make velocity vector
        double velocityX = Math.Cos(angleOfProjection * (Math.PI / 180)) * this.velocity;
        double velocityY = Math.Sin(angleOfProjection * (Math.PI / 180)) * this.velocity;

        this.velocityVector = new Vector2((float)velocityX, (float)velocityY);
    }

    private void FixedUpdate()
    {
        doDisplacement();
        doVelocity();

        this.velocity = this.velocityVector.magnitude;
    }

    void doVelocity()
    {
        Vector2 accelerationVector = new Vector2(0, -this.gravitationalAcceleration);
        velocityVector += Time.deltaTime * accelerationVector;
    }

    void doDisplacement()
    {
        Vector2 translation = Time.deltaTime * velocityVector;

        displacement += translation;
        this.transform.Translate(displacement);
    }
}
