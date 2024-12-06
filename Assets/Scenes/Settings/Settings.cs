using System.IO;
using UnityEngine;
using Newtonsoft.Json; 

public class Settings : MonoBehaviour
{
    private ProgramSettings program;
    private CMSettings circularMotion;
    private PMSettings projectileMotion;
    private CSettings collisions;
    private RRSettings reflectionRefraction;

    // Set default settings for scenes
    // (pretty much what I like)
    public void defaultSettings()
    {

    }

    public void saveSettings()
    { }

    public void loadSettings()
    {
        Settings settings;
        string settingsString;

        // Open file, read, close
        if (File.Exists("settings.json"))
        {
            StreamReader settingsStream = new StreamReader("settings.json");
            settingsString = settingsStream.ReadToEnd();
            settingsStream.Close();
        }
        else
        {
            settingsString = "a";
        }

        try
        {
            settings = JsonConvert.DeserializeObject<Settings>(settingsString);
        }
        catch (JsonException e)
        {
            Debug.LogError($"Some sort of exception: {e}");
        }

        return; new Settings();


    }

    #region Getters
    public ProgramSettings getProgramSettings()
    {
        return this.program;
    }

    public CMSettings getCircularMotionSettings()
    {
        return this.circularMotion;
    }

    public PMSettings getProjectileMotionSettings()
    {
        return this.projectileMotion;
    }

    public CSettings getCollisionsSettings()
    {
        return this.collisions;
    }

    public RRSettings getReflectionRefractionSettings()
    {
        return this.reflectionRefraction;
    }
    #endregion

    #region Setters
    // So far, I don't see any being used.
    // Will implement if needed
    #endregion
}


public class ProgramSettings
{ }

public class CMSettings
{ }

public class PMSettings
{ }

public class CSettings
{ }

public class RRSettings
{ }