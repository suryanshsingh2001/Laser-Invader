using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSet : MonoBehaviour
{
    void Start()
    {
        // Switch to 800 x 600 windowed
        Screen.SetResolution(576, 1024, false);
    }
}
