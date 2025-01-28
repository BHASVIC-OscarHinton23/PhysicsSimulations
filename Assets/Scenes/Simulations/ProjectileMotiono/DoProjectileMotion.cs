using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void Start()
    {
        // Make velocity vector
        double velocityX = Math.Cos(angleOfProjection * (Math.PI / 180)) * this.velocity;
        double velocityY = Math.Sin(angleOfProjection * (Math.PI / 180)) * this.velocity;

        this.velocityVector = new Vector2((float)velocityX, (float)velocityY);
    }

    private void FixedUpdate()
    {
        onUpdate();
    }

    public void onUpdate()
    {
        doDisplacement();
        doVelocity();

        this.velocity = this.velocityVector.magnitude;

        // Check distance from cannon and destroy object if too far away
        if (this.displacement.magnitude > 1000)
        {
            Destroy(this);
        }
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
        this.transform.Translate(translation);
    }
}
