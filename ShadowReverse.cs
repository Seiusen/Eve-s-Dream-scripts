using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowReverse : MonoBehaviour
{

    public float y = 180;
    public float z = 180;

    void Update()
    {
        if((Player_move.lightReverse == true) && Input.GetKeyDown(KeyCode.Space) && (Player_move.isGrounded == true))
        {

            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if((Player_move.lightReverse == false) && Input.GetKeyDown(KeyCode.Space) && (Player_move.isGrounded == true))
        {

            transform.localRotation = Quaternion.Euler(0, y, z);
        }
    }
}
