using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerSix : MonoBehaviour
{
    public static bool sixthNot;

    private void Start() 
    {
        sixthNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            sixthNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            sixthNot = false;
        }
    }
}
