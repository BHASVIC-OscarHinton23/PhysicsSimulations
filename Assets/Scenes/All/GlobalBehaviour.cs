using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Cap FPS at 60, as otherwise it's uncapped (quite bad power-wise, it's just inefficient)
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
