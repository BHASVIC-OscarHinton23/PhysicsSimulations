using System;
using UnityEngine;

public class DoCircularMotion : MonoBehaviour
{
    public GameObject centreOfRotation;
    public float mass;
    public Vector2 gravitationAcceleration;
    public float radius;
    public float period;
    public Boolean useGravity;
    public Vector2 centripetalForce;
    public Vector2 centripetalAcceleration;
    public Vector2 velocity;


    private void FixedUpdate()
    {
        //double angle = getAcuteAngle(centreOfRotation);

        //Debug.Log($"Acute angle: {angle * (180 / Math.PI)} degrees");

        doForces(centreOfRotation);
        doAcceleration();
        updateVelocity(Time.fixedDeltaTime);
        updatePosition(Time.fixedDeltaTime);
    }

    // Get acute angle between this object and a target object, in radians.
    private double getAcuteAngle(GameObject otherObject)
    {
        Vector2 positionA = this.transform.position;
        Vector2 positionB = otherObject.transform.position;
        Vector2 deltaPosition = positionB - positionA;
        double angle = 0;

        // Finding acute angle is different, depending on which quadrant the current object is;
        if (deltaPosition.x > 0 && deltaPosition.y > 0)
        {
            // Top-right quadrant
            angle = Math.Atan(deltaPosition.y / deltaPosition.x);
        }
        else if (deltaPosition.x < 0 && deltaPosition.y > 0)
        {
            // Top-left quadrant
            angle = Math.Atan(deltaPosition.y / Math.Abs(deltaPosition.x));
        }
        else if (deltaPosition.x < 0 && deltaPosition.y < 0)
        {
            // Bottom-left quadrant
            angle = Math.Atan(Math.Abs(deltaPosition.y) / Math.Abs(deltaPosition.x));
        }
        else if (deltaPosition.x > 0 && deltaPosition.y < 0)
        {
            // Bottom-right quadrant
            angle = Math.Atan(Math.Abs(deltaPosition.y) / deltaPosition.x);
        }
        else if (deltaPosition.x == 0)
        {
            // Vertically above or below, so angle is just pi/2
            angle = Math.PI / 2;
        }
        else if (deltaPosition.y == 0)
        {
            // To the left or right, so angle is 0
            angle = 0d;
        }
        else
        {
            Debug.LogError($"Failed to find angle. delta:({deltaPosition.x},{deltaPosition.y})");
        }

        if (angle > (Math.PI / 4))
        {
            angle = (Math.PI / 2) - angle;
        }

        return angle;
    }

    private void updatePosition(float fixedDeltaTime)
    {
        this.transform.Translate(this.velocity *  fixedDeltaTime);
    }

    private void updateVelocity(float fixedDeltaTime)
    {
        this.velocity += this.centripetalAcceleration * fixedDeltaTime;
    }

    private void doAcceleration()
    {
        this.centripetalAcceleration = this.centripetalForce / this.mass;
    }

    private void doForces(GameObject otherObject)
    {
        Vector2 resultantForce = new Vector2(0, 0);
        double angle = getAcuteAngle(this.centreOfRotation);

        // Get distance and direction vector
        double distance = (otherObject.transform.position - this.transform.position).magnitude;
        Vector2 direction = (otherObject.transform.position - this.transform.position).normalized;

        double forceX = ((4 * Math.Pow(Math.PI, 2) * radius * mass) / Math.Pow(period, 2)) * Math.Cos(angle);
        double forceY = ((4 * Math.Pow(Math.PI, 2) * radius * mass) / Math.Pow(period, 2)) * Math.Sin(angle);

        direction.x *= (float)forceX;
        direction.y *= (float)forceY;

        this.centripetalForce = direction;
    }
}
