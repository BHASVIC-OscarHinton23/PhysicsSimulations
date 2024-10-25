using System.Collections;
using System.Collections.Generic;
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
        Vector2 mousePosition = Input.mousePosition;

        Debug.Log($"Mouse information: X={mousePosition.x} Y={mousePosition.y}");
    }
}
