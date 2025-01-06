using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanelCM : MonoBehaviour
{
    public GameObject body;
    public GameObject massPanel;
    public GameObject radiusPanel;
    public GameObject periodPanel;
    public GameObject CFPanel;
    public GameObject CFHorizontalPanel;
    public GameObject CFVerticalPanel;
    public GameObject CAPanel;
    public GameObject CAHorizontalPanel;
    public GameObject CAVerticalPanel;
    public GameObject velocityPanel;
    public GameObject velocityHorizontalPanel;
    public GameObject velocityVerticalPanel;

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
        DoCircularMotion cmComponent = body.GetComponent<DoCircularMotion>();
        GameObject slider = massPanel.transform.Find("Slider").gameObject;
        Slider sliderComponent = slider.GetComponent<Slider>();
        cmComponent.mass = sliderComponent.value;
    }
    #endregion

    #region Radius Listeners

    // Update label stating the current value
    public void updateRadiusLabel(float value)
    {
        GameObject slider = radiusPanel.transform.Find("Slider").gameObject;
        GameObject textLabel = radiusPanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"Radius: {sliderComponent.value} m";
    }


    // Listener for lower bound text input
    public void changeRadiusLowerBound(string value)
    {
        GameObject lowerBound = radiusPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = radiusPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = radiusPanel.transform.Find("Slider").gameObject;
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
    public void changeRadiusUpperBound(string value)
    {
        GameObject lowerBound = radiusPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = radiusPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = radiusPanel.transform.Find("Slider").gameObject;
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

    public void radiusSliderListener(float value)
    {
        DoCircularMotion cmComponent = body.GetComponent<DoCircularMotion>();
        GameObject slider = radiusPanel.transform.Find("Slider").gameObject;
        Slider sliderComponent = slider.GetComponent<Slider>();

        setNewVelocityRadius(sliderComponent.value, cmComponent.radius);
        setNewRadius(sliderComponent.value);
        cmComponent.radius = sliderComponent.value;
    }

    void setNewRadius(float newRadius)
    {
        // For new radius to take effect, must translate so that body is that distance away
        // This should also prevent the weird elliptical motion when radius is changed (as the body's distance actually changes)

        // Unit vector in direction of COR
        GameObject COR = GameObject.Find("CentreOfRotation");
        Vector2 directionVectorCOR = (COR.transform.position - body.transform.position).normalized;
        Vector2 directionVectorAway = -directionVectorCOR;

        // Make displacement vector by multiplying directionVectorAway by difference in radius
        // old radius should be current radius of body
        float oldRadius = body.GetComponent<DoCircularMotion>().radius;
        float deltaRadius = (newRadius - oldRadius);

        directionVectorAway *= deltaRadius;

        // Translate body
        body.transform.Translate(directionVectorAway);

    }

    void setNewVelocityRadius(float newRadius, float oldRadius)
    {
        DoCircularMotion cmComponent = body.GetComponent<DoCircularMotion>();

        // When changing R, v also needs to be adjusted
        // For V0 = wr0, v1 = wr1
        // |v1| / |v0| gives multiple for vel change
        // so v0.normalised * |v1| / |v0| gives new velocity
        double magnitudeOldVelocity = (2 * Math.PI / cmComponent.period) * oldRadius;
        double magnitudeNewVelocity = (2 * Math.PI / cmComponent.period) * newRadius;
        double velocityChangeMultiplier = magnitudeNewVelocity / magnitudeOldVelocity;

        cmComponent.velocity *= (float)velocityChangeMultiplier;
    }
    #endregion

    #region Period Listeners

    // Update label stating the current value
    public void updatePeriodLabel(float value)
    {
        GameObject slider = periodPanel.transform.Find("Slider").gameObject;
        GameObject textLabel = periodPanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"Period: {sliderComponent.value} s";
    }


    // Listener for lower bound text input
    public void changePeriodLowerBound(string value)
    {
        GameObject lowerBound = periodPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = periodPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = periodPanel.transform.Find("Slider").gameObject;
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
    public void changePeriodUpperBound(string value)
    {
        GameObject lowerBound = periodPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = periodPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = periodPanel.transform.Find("Slider").gameObject;
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

    public void periodSliderListener(float value)
    {
        DoCircularMotion cmComponent = body.GetComponent<DoCircularMotion>();
        GameObject slider = periodPanel.transform.Find("Slider").gameObject;
        Slider sliderComponent = slider.GetComponent<Slider>();

        setNewVelocityPeriod(sliderComponent.value, cmComponent.period);
        cmComponent.period = sliderComponent.value;
    }

    void setNewVelocityPeriod(float newPeriod, float oldPeriod)
    {
        DoCircularMotion cmComponent = body.GetComponent<DoCircularMotion>();

        // When changing R, v also needs to be adjusted
        // For V0 = wr0, v1 = wr1
        // |v1| / |v0| gives multiple for vel change
        // so v0.normalised * |v1| / |v0| gives new velocity
        double magnitudeOldVelocity = (2 * Math.PI / oldPeriod) * cmComponent.radius;
        double magnitudeNewVelocity = (2 * Math.PI / newPeriod) * cmComponent.radius;
        double velocityChangeMultiplier = magnitudeNewVelocity / magnitudeOldVelocity;

        cmComponent.velocity *= (float)velocityChangeMultiplier;
    }
    #endregion

    #region Centripetal Force Listeners

    // Update label stating the current value
    public void updateCFLabel(Vector2 value)
    {
        GameObject textLabel = CFPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Centripetal Force: {value.magnitude:0.00} N";

        // Components
        updateCFHorizontalLabel(value.x);
        updateCFVerticalLabel(value.y);
    }

    public void updateCFHorizontalLabel(float value)
    {
        GameObject textLabel = CFHorizontalPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Horizontal: {value:0.00} N";
    }

    public void updateCFVerticalLabel(float value)
    {
        GameObject textLabel = CFVerticalPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Vertical: {value:0.00} N";
    }

    #endregion

    #region Centripetal Acceleration Listeners

    // Update label stating the current value
    public void updateCALabel(Vector2 value)
    {
        GameObject textLabel = CAPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Centripetal Acceleration: {value.magnitude:0.00} m/s²";

        // Components
        updateCAHorizontalLabel(value.x);
        updateCAVerticalLabel(value.y);
    }

    public void updateCAHorizontalLabel(float value)
    {
        GameObject textLabel = CAHorizontalPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Horizontal: {value:0.00} m/s²";
    }

    public void updateCAVerticalLabel(float value)
    {
        GameObject textLabel = CAVerticalPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Vertical: {value:0.00} m/s²";
    }

    #endregion

    #region Velocity Listeners

    // Update label stating the current value
    public void updateVelocityLabel(Vector2 value)
    {
        GameObject textLabel = velocityPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Tangential Velocity: {value.magnitude:0.00} m/s";

        // Components
        updateVelocityHorizontalLabel(value.x);
        updateVelocityVerticalLabel(value.y);
    }

    public void updateVelocityHorizontalLabel(float value)
    {
        GameObject textLabel = velocityHorizontalPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Horizontal: {value:0.00} m/s";
    }

    public void updateVelocityVerticalLabel(float value)
    {
        GameObject textLabel = velocityVerticalPanel.transform.Find("VariableName").gameObject;
        textLabel.GetComponent<TextMeshProUGUI>().text = $"Vertical: {value:0.00} m/s";
    }

    #endregion

}
