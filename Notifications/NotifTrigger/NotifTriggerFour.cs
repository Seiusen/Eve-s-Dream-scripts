using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerFour : MonoBehaviour
{
    public static bool fourthNot;

    private void Start() 
    {
        fourthNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            fourthNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            fourthNot = false;
        }
    }
}
