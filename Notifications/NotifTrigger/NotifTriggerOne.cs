using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerOne : MonoBehaviour
{
    public static bool firstNot;

    private void Start() 
    {
        firstNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            firstNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            firstNot = false;
        }
    }
}
