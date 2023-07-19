using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEyeWalk : MonoBehaviour
{
    void Update()
    {
        if((Player_move.rightWalking == false) && (Player_move.lightIdle == false))
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = true;
        }
        else
        {
            GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
        }
    }
}
