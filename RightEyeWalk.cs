using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEyeWalk : MonoBehaviour
{
    void Update()
    {
        if((Player_move.rightWalking == true) && (Player_move.lightIdle == false))
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = true;
        }
        else
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
        }
    }
}
