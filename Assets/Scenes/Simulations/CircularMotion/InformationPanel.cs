using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public GameObject body;
    public GameObject massPanel;
    public GameObject radiusPanel;
    public GameObject periodPanel;
    public GameObject CFPanel;
    public GameObject CAPanel;
    public GameObject velocityPanel;

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
        if (lowerValue >= upperValue || lowerValue < 0)
        {
            lower.text = "0";
            slider.minValue = 0;

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

    #region Velocity Listeners (example)

    // Update label stating the current value
    public void updateVelocityLabel(float value)
    {
        GameObject slider = velocityPanel.transform.Find("Slider").gameObject;
        GameObject textLabel = velocityPanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"Velocity: {sliderComponent.value} m/s";
    }


    // Listener for lower bound text input
    public void changeVelocityLowerBound(string value)
    {
        GameObject lowerBound = velocityPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = velocityPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = velocityPanel.transform.Find("Slider").gameObject;
        Slider slider = sliderObject.GetComponent<Slider>();
        TMP_InputField lower = lowerBound.GetComponent<TMP_InputField>();
        TMP_InputField upper = upperBound.GetComponent<TMP_InputField>();

        float lowerValue = float.Parse(lower.text);
        float upperValue = float.Parse(upper.text);

        // Check if value is greater than maximum, or if below 0
        // Set to 0 and return if so
        if (lowerValue >= upperValue || lowerValue < 0)
        {
            lower.text = "0";
            slider.minValue = 0;

            return;
        }

        // Change lower bound to what was inputted
        slider.minValue = lowerValue;
    }


    // Listener for upper bound text input
    public void changeVelocityUpperBound(string value) 
    {
        GameObject lowerBound = velocityPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = velocityPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = velocityPanel.transform.Find("Slider").gameObject;
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

    #endregion

    #region Period Listeners (example)

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
        if (lowerValue >= upperValue || lowerValue < 0)
        {
            lower.text = "0";
            slider.minValue = 0;

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

    #endregion

    #region Centripetal Force Listeners (example)

    // Update label stating the current value
    public void updateCFLabel(float value)
    {
        GameObject slider = CFPanel.transform.Find("Slider").gameObject;
        GameObject textLabel = CFPanel.transform.Find("VariableName").gameObject;
        TextMeshProUGUI textComponent = textLabel.GetComponent<TextMeshProUGUI>();
        Slider sliderComponent = slider.GetComponent<Slider>();

        textComponent.text = $"Centripetal Force: {sliderComponent.value} N";
    }


    // Listener for lower bound text input
    public void changeCFLowerBound(string value)
    {
        GameObject lowerBound = CFPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = CFPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = CFPanel.transform.Find("Slider").gameObject;
        Slider slider = sliderObject.GetComponent<Slider>();
        TMP_InputField lower = lowerBound.GetComponent<TMP_InputField>();
        TMP_InputField upper = upperBound.GetComponent<TMP_InputField>();

        float lowerValue = float.Parse(lower.text);
        float upperValue = float.Parse(upper.text);

        // Check if value is greater than maximum, or if below 0
        // Set to 0 and return if so
        if (lowerValue >= upperValue || lowerValue < 0)
        {
            lower.text = "0";
            slider.minValue = 0;

            return;
        }

        // Change lower bound to what was inputted
        slider.minValue = lowerValue;
    }


    // Listener for upper bound text input
    public void changeCFUpperBound(string value)
    {
        GameObject lowerBound = CFPanel.transform.Find("LowerBound").gameObject;
        GameObject upperBound = CFPanel.transform.Find("UpperBound").gameObject;
        GameObject sliderObject = CFPanel.transform.Find("Slider").gameObject;
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

    #endregion
}
