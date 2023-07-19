using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerTenth : MonoBehaviour
{
    public static bool tenthNot;

    private void Start() 
    {
        tenthNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            tenthNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            tenthNot = false;
        }
    }
}
