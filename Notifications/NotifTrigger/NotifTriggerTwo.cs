using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerTwo : MonoBehaviour
{
    public static bool secondNot;

    private void Start() 
    {
        secondNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            secondNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            secondNot = false;
        }
    }
}
