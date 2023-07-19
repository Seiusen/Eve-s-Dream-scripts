using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReverse : MonoBehaviour
{
    public float reverse = 4.548f;
    

    void Update()
    {
        if((Player_move.lightReverse == true) && Input.GetKeyDown(KeyCode.Space) && (Player_move.isGrounded == true))
        {
            transform.position += new Vector3(0, reverse, 0);
        }
        else if((Player_move.lightReverse == false) && Input.GetKeyDown(KeyCode.Space) && (Player_move.isGrounded == true))
        {
            transform.position -= new Vector3(0, reverse, 0);
        }
    }

}
