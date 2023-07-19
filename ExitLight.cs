using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLight : MonoBehaviour
{

    void Update()
    {
        if(ExitButton.lighting == true)
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = true;
        }
        else
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
        }
    }
}
