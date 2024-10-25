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
        DisplayInfo info = Screen.mainWindowDisplayInfo;
        int windowHeight = info.height;
        int windowWidth = info.width;

        // Checks for if the mouse is outside of the window area
        // If either are negative, the mouse is DEFINITELY not inside the window's boundaries
        // If mouse.X > window width, the mouse is outside.
        // Likewise with mouse.Y > window height
        if (mousePosition.x < 0 || mousePosition.y < 0 || mousePosition.x > windowWidth || mousePosition.y > windowHeight)
        {
            Debug.Log("Outside");
            // Can just return here, no need to set hovering to false.
            // (they can't just stop hovering and move the mouse that far, that quickly)
            return;
        }
        Debug.Log("Inside");
        
        //Debug.Log($"Mouse information: X={mousePosition.x} Y={mousePosition.y}");
    }
}
