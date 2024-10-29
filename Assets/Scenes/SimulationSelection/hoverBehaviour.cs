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

        Debug.Log($"Mouse information: X={mousePosition.x} Y={mousePosition.y}");
        //Debug.Log($"Screen information: X={windowWidth} Y={windowHeight}");

        // Get rect height and width of panel
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        Rect rect = rectTransform.rect;

        // Unlike the screen information, this is relative to the GameObject's RectTransform anchor points
        // To get the position on the scene, we have to subtract the anchor points' X and Y coordinates.
        // https://docs.unity3d.com/ScriptReference/Rect.html
        // https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/class-RectTransform.html

        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        Vector2 bottomLeft = corners[0];
        Vector2 topLeft = corners[1];
        Vector2 topRight = corners[2];
        Vector2 bottomRight = corners[3];
        
        
        //Vector2 topLeft = new Vector2(rect.xMin - rectTransform.anchorMin.x, rect.yMin - rectTransform.anchorMax.y);
        //Vector2 topRight = new Vector2(rect.xMax - rectTransform.anchorMax.x, rect.yMin - rectTransform.anchorMax.y);
        //Vector2 bottomLeft = new Vector2(rect.xMin - rectTransform.anchorMin.x, rect.yMax - rectTransform.anchorMin.y);
        //Vector2 bottomRight = new Vector2(rect.xMax - rectTransform.anchorMax.x, rect.yMax - rectTransform.anchorMax.y);

        //Debug.Log($"Anchor max: ({rectTransform.anchorMax.x},{rectTransform.anchorMax.y})");
        //Debug.Log($"Anchor max: ({rectTransform.anchorMin.x},{rectTransform.anchorMin.y})");

        Debug.Log($"Top-left: ({topLeft.x},{topLeft.y})");
        Debug.Log($"Top-right: ({topRight.x},{topRight.y})");
        Debug.Log($"Bottom-left: ({bottomLeft.x},{bottomLeft.y})");
        Debug.Log($"Bottom-right: ({bottomRight.x},{bottomRight.y})");
    }
}
