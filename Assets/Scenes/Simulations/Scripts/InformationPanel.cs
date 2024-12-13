using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformationPanel : MonoBehaviour
{
    public GameObject velocityPanel;

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
}
