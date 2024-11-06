using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    public void changeToSettings()
    {
        Debug.Log("Switching scene: Settings");
        SceneManager.LoadScene("Settings");
    }

    public void changeToTemplateSimulation()
    {
        Debug.Log("Switching scene: TemplateSimulation");
        SceneManager.LoadScene("TemplateSimulation");
    }
}
