using System;
using UnityEngine;

public class DoCircularMotion : MonoBehaviour
{
    public GameObject centreOfRotation;
    public float mass;
    public float radius;
    public float period;
    public Boolean useGravity;
    public Vector2 centripetalForce;
    public Vector2 centripetalAcceleration;
    public Vector2 gravitationAcceleration;
    public Vector2 velocity;


    private void Start()
    {
        // Actually calculate what the values should be at the start of the scene

        // Distance:
        this.radius = (this.centreOfRotation.transform.position - this.transform.position).magnitude;

        // Velocity calculations
        // Body starts to the east so x comp is just 0 (it's going vertically)
        // v = omega * r
        // omega = 2 pi / period

        double velocityY = (2 * Math.PI / this.period) * this.radius;
        this.velocity = new Vector2(0, (float)velocityY);
    }

    private void FixedUpdate()
    {
        //double angle = getAcuteAngle(centreOfRotation);

        //Debug.Log($"Acute angle: {angle * (180 / Math.PI)} degrees");

        // Calculate distance
        this.radius = (this.centreOfRotation.transform.position - this.transform.position).magnitude;

        doForces(centreOfRotation);
        doAcceleration();
        updateVelocity(Time.fixedDeltaTime);
        updatePosition(Time.fixedDeltaTime);

        // Update UI elements
        GameObject globalObject = GameObject.Find("Global");
        InformationPanel infoPanelComponent = globalObject.GetComponent<InformationPanel>();

        infoPanelComponent.updateCFLabel(this.centripetalForce);
        infoPanelComponent.updateCALabel(this.centripetalAcceleration);
        infoPanelComponent.updateVelocityLabel(this.velocity);
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
        this.transform.Translate(this.velocity * fixedDeltaTime);
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
        double angle = getAcuteAngle(this.centreOfRotation);

        // Get distance and direction vector
        double distance = (otherObject.transform.position - this.transform.position).magnitude;
        Vector2 direction = (otherObject.transform.position - this.transform.position).normalized;

        double force = ((4 * Math.Pow(Math.PI, 2) * radius * mass) / Math.Pow(period, 2));

        direction.x *= (float)force;
        direction.y *= (float)force;

        this.centripetalForce = direction;
    }
}
