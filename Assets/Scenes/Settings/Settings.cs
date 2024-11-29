using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Rendering;

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

    public Settings loadSettings()
    { }

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