using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateInfoLabels : MonoBehaviour
{
    // Last projectile to be launched
    public GameObject lastProjectile;

    public float timeSinceLaunch = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lastProjectile is null || lastProjectile.GetComponent<DoProjectileMotion>() == null)
        {
            return;            
        }

        DoProjectileMotion pmComponent = this.lastProjectile.GetComponent<DoProjectileMotion>();

        GameObject velocityPanel = GameObject.Find("VelocityPanel");
        GameObject velocityXPanel = GameObject.Find("VelocityXPanel");
        GameObject velocityYPanel = GameObject.Find("VelocityYPanel");
        
        GameObject displacementPanel = GameObject.Find("DisplacementPanel");
        GameObject displacementXPanel = GameObject.Find("DisplacementXPanel");
        GameObject displacementYPanel = GameObject.Find("DisplacementYPanel");

        GameObject timePanel = GameObject.Find("TimePanel");

        velocityPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Velocity: {pmComponent.velocity} m/s";
        velocityXPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Horizontal: {pmComponent.velocityVector.x} m/s";
        velocityYPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Vertical: {pmComponent.velocityVector.y} m/s";

        displacementPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Displacement: {pmComponent.displacement.magnitude} m";
        displacementXPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Horizontal: {pmComponent.displacement.x} m";
        displacementYPanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Vertical: {pmComponent.displacement.y} m";

        timePanel.GetComponentInChildren<TextMeshProUGUI>().text = $"Time since launch: {this.timeSinceLaunch} s";
        this.timeSinceLaunch += Time.fixedDeltaTime;
    }
}
