using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesIdleOff : MonoBehaviour
{

    void Update()
    {
        if(Player_move.lightIdle == true)
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = true;
        }
        else if(Player_move.lightIdle == false)
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
        }
    }
}
