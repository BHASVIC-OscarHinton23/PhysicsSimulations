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

    public GameObject initialVelocityPanel;

    public GameObject cannonBarrel;
    public GameObject massPanel;
    public GameObject gravityPanel;
    public GameObject anglePanel;

    float timeSinceLaunch = 0;

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
        pmScript.gravitationalAcceleration = gravityPanel.GetComponentInChildren<Slider>().value;
        pmScript.angleOfProjection = anglePanel.GetComponentInChildren<Slider>().value;
        pmScript.velocity = initialVelocityPanel.GetComponentInChildren<Slider>().value;

        // Do some info label stuff to keep track of last launched projectile
        UpdateInfoLabels updateInfoLabelComponent = this.GetComponentInParent<UpdateInfoLabels>();
        updateInfoLabelComponent.enabled = true;
        updateInfoLabelComponent.lastProjectile = this.projectile;

        // Reset timer to 0 to start counting again
        updateInfoLabelComponent.timeSinceLaunch = 0;
    }

    public void pathDrawingProjectileCreate()
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
        GameObject projectile = (GameObject)Instantiate(this.baseProjectile, simulationObjects.transform);

        projectile.transform.position = startPosition;
        projectile.AddComponent<DoProjectileMotion>();

        // Set values for PM
        // Start is called on next update so all should be fine
        DoProjectileMotion pmScript = projectile.GetComponent<DoProjectileMotion>();
        pmScript.mass = massPanel.GetComponentInChildren<Slider>().value;
        pmScript.gravitationalAcceleration = gravityPanel.GetComponentInChildren<Slider>().value;
        pmScript.angleOfProjection = anglePanel.GetComponentInChildren<Slider>().value;
        pmScript.velocity = initialVelocityPanel.GetComponentInChildren<Slider>().value;
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
        // Mass doesn't actually have any effect on the simulation, so we really don't need to update anything when
        // the slider is used. This also fixes an error :)

        //DoProjectileMotion pmComponent = this.projectile.GetComponent<DoProjectileMotion>();
        //GameObject slider = massPanel.transform.Find("Slider").gameObject;
        //Slider sliderComponent = slider.GetComponent<Slider>();
        //pmComponent.mass = sliderComponent.value;
    }
    #endregion

    #region Initial Velocity listeners

    public void updateInitialVelocityLabel(float value)
    {
        GameObject slider = this.initialVelocityPanel.transform.Find("Slider").gameObject;
        GameObject textLabel = this.initialVelocityPanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"Start Velocity: {sliderComponent.value} m/s";
    }
    public void changeInitialVelocityUpperBound(string value)
    {
        GameObject lowerBound = this.initialVelocityPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = this.initialVelocityPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = this.initialVelocityPanel.transform.Find("Slider").gameObject;
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
    public void changeInitialVelocityLowerBound(string value)
    {
        GameObject lowerBound = this.initialVelocityPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = this.initialVelocityPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = this.initialVelocityPanel.transform.Find("Slider").gameObject;
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


    #endregion

    #region Gravitational Acceleration listeners
    public void updateAccelerationLabel(float value)
    {
        GameObject slider = this.gravityPanel.transform.Find("Slider").gameObject;
        GameObject textLabel = this.gravityPanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"g: {sliderComponent.value} m/s²";
    }
    public void changeAccelerationUpperBound(string value)
    {
        GameObject lowerBound = this.gravityPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = this.gravityPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = this.gravityPanel.transform.Find("Slider").gameObject;
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
    public void changeAccelerationLowerBound(string value)
    {
        GameObject lowerBound = this.gravityPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = this.gravityPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = this.gravityPanel.transform.Find("Slider").gameObject;
        Slider slider = sliderObject.GetComponent<Slider>();
        TMP_InputField lower = lowerBound.GetComponent<TMP_InputField>();
        TMP_InputField upper = upperBound.GetComponent<TMP_InputField>();

        float lowerValue = float.Parse(lower.text);
        float upperValue = float.Parse(upper.text);

        
        // Check if value is greater than maximum
        // Set to 0 and return if so
        // slight change, allow values below 0! i think it'd be funny (i've slept 1 hour)
        if (lowerValue >= upperValue)
        {
            lower.text = "0.001";
            slider.minValue = 0.001f;

            return;
        }

        // Change lower bound to what was inputted
        slider.minValue = lowerValue;
    }
    #endregion

    #region Angle Listeners

    // Rotate cannon to match angle
    public void rotateCannon(float angle)
    {
        GameObject cannon = GameObject.Find("Cannon");

        // Reset rotation
        cannon.transform.rotation = Quaternion.Euler(0, 0, 0);

        cannon.transform.Rotate(0, 0, angle);
    }

    public void updateAngleLabel(float value)
    {
        GameObject slider = this.anglePanel.transform.Find("Slider").gameObject;
        GameObject textLabel = this.anglePanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"Angle: {sliderComponent.value} degrees";
    }
    #endregion
}
