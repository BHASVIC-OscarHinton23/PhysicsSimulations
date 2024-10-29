using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class hoverBehaviour : MonoBehaviour
{
    public bool hovering;

    // Start is called before the first frame update
    void Start()
    {
        hovering = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkForHover();
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
        if (mousePosition.x < 0 || mousePosition.y < 0 || mousePosition.x > windowWidth || mousePosition.y > windowHeight)
        {
            //Debug.Log("Outside");
            // Can just return here, no need to set hovering to false.
            // (they can't just stop hovering and move the mouse that far, that quickly)
            return;
        }
        //Debug.Log("Inside");

        //Debug.Log($"Mouse information: X={mousePosition.x} Y={mousePosition.y}");
        //Debug.Log($"Screen information: X={windowWidth} Y={windowHeight}");

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
            //Debug.Log("Hovering over panel/");

            hovering = true;
        }
        else
        {
            // NOT over the panel!
            //Debug.Log("Not hovering over panel.");
            hovering = false;
        }

        //Debug.Log($"In X range: {inXRange}");
        //Debug.Log($"In Y range: {inYRange}");


        //Debug.Log($"Top-left: ({topLeft.x},{topLeft.y})");
        //Debug.Log($"Top-right: ({topRight.x},{topRight.y})");
        //Debug.Log($"Bottom-left: ({bottomLeft.x},{bottomLeft.y})");
        //Debug.Log($"Bottom-right: ({bottomRight.x},{bottomRight.y})");
    }
}
