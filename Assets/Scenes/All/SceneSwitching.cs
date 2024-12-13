using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    public void exitProgram()
    {
        Debug.Log("Closing application");
        Application.Quit();
    }

    public void changeToSettings()
    {
        Debug.Log("Switching scene: Settings");
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void changeToTemplateSimulation()
    {
        Debug.Log("Switching scene: TemplateSimulation");
        SceneManager.LoadScene("template", LoadSceneMode.Single);
    }
}
