using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerSeventh : MonoBehaviour
{
    public static bool seventhNot;

    private void Start() 
    {
        seventhNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            seventhNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            seventhNot = false;
        }
    }
}
