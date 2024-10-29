using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class hoverBehaviour : MonoBehaviour
{
    public bool hovering;
    public float scaleFactor = 1;
    public float maxScaleFactor = 2;
    public int scaleFactorIntervalPercentage = 10; // Change by 10% each update
    public int numberOfIntervals = 0; // Keep track of current number of intervals scaled by

    public Vector3 initialScale;
    public Vector3 maximumScale;
    public Vector3 scaleDifference;

    // Start is called before the first frame update
    void Start()
    {
        hovering = false;
        this.initialScale = this.transform.localScale;
        this.maximumScale = this.initialScale * maxScaleFactor;
        this.scaleDifference = this.maximumScale - this.initialScale;
    }

    // Update is called once per frame
    void Update()
    {
        checkForHover();

        if (hovering)
        {
            growInSize();
        }
        else
        {
            shrinkInSize();
        }
    }

    // Check if mouse is hovering over panel, and update `hovering` accordingly.
    void checkForHover()
    {
        // Mouse position is relative to bottom-left of window, not screen
        // (i.e 0,0 is the bottom left corner)
        Vector2 mousePosition = Input.mousePosition;

        // Information about the program's window
        int windowHeight = Screen.height;
        int windowWidth = Screen.width;

        // Checks for if the mouse is outside of the window area
        // If either are negative, the mouse is DEFINITELY not inside the window's boundaries
        // If mouse.X > window width, the mouse is outside.
        // Likewise with mouse.Y > window height
        bool withinScreenX = mousePosition.x > 0 && mousePosition.x < windowWidth;
        bool withinScreenY = mousePosition.y > 0 && mousePosition.y < windowHeight;

        if (!(withinScreenX && withinScreenY))
        {
            // Can just return here, no need to set hovering to false.
            // (they can't just stop hovering and move the mouse that far, that quickly)
            return;
        }

        // Get rect height and width of panel
        RectTransform rectTransform = this.GetComponent<RectTransform>();

        // Unlike the screen information, this is relative to the RectTransform anchor points
        // To get the position on the scene, use GetWorldCorners to get the corners of the rect in world space
        // These coordinates are also where that point is on the screen, giving us the corner locations
        // https://docs.unity3d.com/ScriptReference/RectTransform.html
        // https://docs.unity3d.com/ScriptReference/RectTransform.GetWorldCorners.html

        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        Vector2 bottomLeft = corners[0];
        Vector2 topLeft = corners[1];
        Vector2 topRight = corners[2];
        Vector2 bottomRight = corners[3];

        // Like before, check if mouse is over panel by comparing coordinates of corners and mouse
        bool inXRange = mousePosition.x > topLeft.x && mousePosition.x < topRight.x;
        bool inYRange = mousePosition.y < topLeft.y && mousePosition.y > bottomLeft.y;
        
        if (inXRange && inYRange)
        {
            // Over the panel!
            hovering = true;
        }
        else
        {
            // NOT over the panel!
            hovering = false;
        }
    }
    void growInSize()
    {
        if (this.scaleFactor >= this.maxScaleFactor)
        {
            // Current scale factor is equal to the maximum allowed
            this.scaleFactor = this.maxScaleFactor;
            return;
        }

        this.scaleFactor += this.scaleFactorInterval;

        changeScale();
    }

    void shrinkInSize()
    {
        if (this.scaleFactor <= 1)
        {
            // If scale factor is below 1, the panel shrinks below the normal size
            this.scaleFactor = 1;
            
            return;
        }

        this.scaleFactor -= this.scaleFactorInterval;

        changeScale();
    }

    void changeScale()
    {
        // Find how much to scale by on x and y axis
        Vector3 scaleBy = this.initialScale;
        scaleBy.x += scaleDifference.x * (scaleFactorIntervalPercentage/100) * numberOfIntervals;
        scaleBy.y += scaleDifference.y * (scaleFactorIntervalPercentage / 100) * numberOfIntervals;

        // Reset scale, and then scale properly
        this.transform.localScale = this.initialScale;
        this.transform.localScale = new Vector3(scaleBy.x, scaleBy.y, 1);
    }

}
