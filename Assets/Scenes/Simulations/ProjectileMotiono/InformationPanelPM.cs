using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanelPM : MonoBehaviour
{
    // baseProjectile is the object which projectiles are copied from
    public GameObject baseProjectile;

    // projectile is the last projectile to be shot out of cannon
    public GameObject projectile;
    public GameObject cannonBarrel;
    public GameObject massPanel;
    public GameObject velocitySlider;
    public GameObject gravitySlider;
    public GameObject angleSlider;

    public void launchButtonListener()
    {
        Debug.Log("launch button pressed");

        // Get end corners of barrel
        Vector3[] cannonRectVertices = new Vector3[4];
        this.cannonBarrel.GetComponent<RectTransform>().GetWorldCorners(cannonRectVertices);

        Vector2 pointA = cannonRectVertices[2];
        Vector2 pointB = cannonRectVertices[3];

        // Get average of corners
        Vector2 startPosition = (pointA + pointB) / 2;

        // Create projectile
        // this.projectile is a throwaway projectile that is never used
        GameObject simulationObjects = GameObject.Find("Simulation");
        this.projectile = (GameObject) Instantiate(this.baseProjectile, simulationObjects.transform);

        this.projectile.transform.position = startPosition;
        this.projectile.AddComponent<DoProjectileMotion>();

        // Set values for PM
        // Start is called on next update so all should be fine
        DoProjectileMotion pmScript = this.projectile.GetComponent<DoProjectileMotion>();
        pmScript.mass = massPanel.GetComponentInChildren<Slider>().value;
        pmScript.gravitationalAcceleration = gravitySlider.GetComponent<Slider>().value;
        pmScript.angleOfProjection = angleSlider.GetComponent<Slider>().value;
        pmScript.velocity = velocitySlider.GetComponent<Slider>().value;
    }


    #region Mass Listeners

    // Update label stating the current value
    public void updateMassLabel(float value)
    {
        GameObject slider = massPanel.transform.Find("Slider").gameObject;
        GameObject textLabel = massPanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"Mass: {sliderComponent.value} kg";
    }


    // Listener for lower bound text input
    public void changeMassLowerBound(string value)
    {
        GameObject lowerBound = massPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = massPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = massPanel.transform.Find("Slider").gameObject;
        Slider slider = sliderObject.GetComponent<Slider>();
        TMP_InputField lower = lowerBound.GetComponent<TMP_InputField>();
        TMP_InputField upper = upperBound.GetComponent<TMP_InputField>();

        float lowerValue = float.Parse(lower.text);
        float upperValue = float.Parse(upper.text);

        // Check if value is greater than maximum, or if below 0
        // Set to 0 and return if so
        if (lowerValue >= upperValue || lowerValue <= 0)
        {
            lower.text = "0.001";
            slider.minValue = 0.001f;

            return;
        }

        // Change lower bound to what was inputted
        slider.minValue = lowerValue;
    }


    // Listener for upper bound text input
    public void changeMassUpperBound(string value)
    {
        GameObject lowerBound = massPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = massPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = massPanel.transform.Find("Slider").gameObject;
        Slider slider = sliderObject.GetComponent<Slider>();
        TMP_InputField lower = lowerBound.GetComponent<TMP_InputField>();
        TMP_InputField upper = upperBound.GetComponent<TMP_InputField>();

        float lowerValue = float.Parse(lower.text);
        float upperValue = float.Parse(upper.text);

        // Check if value is greater than maximum, or if below 0
        // Set to 0 and return if so
        if (upperValue <= lowerValue)
        {
            upper.text = $"{lowerValue + 1}";
            slider.minValue = lowerValue + 1;

            return;
        }

        // Change lower bound to what was inputted
        slider.maxValue = upperValue;
    }

    public void massSliderListener(float value)
    {
        DoCircularMotion cmComponent = this.projectile.GetComponent<DoCircularMotion>();
        GameObject slider = massPanel.transform.Find("Slider").gameObject;
        Slider sliderComponent = slider.GetComponent<Slider>();
        cmComponent.mass = sliderComponent.value;
    }
    #endregion

}
