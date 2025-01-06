using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanelPM : MonoBehaviour
{
    public GameObject throwawayProjectile;
    public GameObject cannonBarrel;
    public GameObject massPanel;
    public GameObject velocityPanel;
    public GameObject gravityPanel;
    public GameObject anglePanel;

    public void launchButtonListener()
    {
        Debug.Log("launch button pressed");

        // Get end corners of barrel
        Vector3[] cannonRectVertices = new Vector3[4];
        this.cannonBarrel.GetComponent<RectTransform>().GetWorldCorners(cannonRectVertices);

        Vector2 pointA = cannonRectVertices[2];
        Vector2 pointB = cannonRectVertices[3];

        // Get average of corners
        Vector2 startPosition = pointA + pointB / 2;

        // Create projectile
        // this.projectile is a throwaway projectile that is never used
        GameObject simulationObjects = GameObject.Find("Simulation");
        GameObject projectile = (GameObject) Instantiate(this.throwawayProjectile, simulationObjects.transform);

        projectile.transform.position = startPosition;
        projectile.AddComponent<DoProjectileMotion>();

        // Set values for PM
        // Start is called on next update so all should be fine
        DoProjectileMotion pmScript = projectile.GetComponent<DoProjectileMotion>();
        pmScript.mass = massPanel.GetComponent<Slider>().value;
        pmScript.gravitationalAcceleration = gravityPanel.GetComponent<Slider>().value;
        pmScript.angleOfProjection = anglePanel.GetComponent<Slider>().value;
        pmScript.velocity = velocityPanel.GetComponent<Slider>().value;
    }
}
