using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerEighth : MonoBehaviour
{
    public static bool eighthNot;

    private void Start() 
    {
        eighthNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            eighthNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            eighthNot = false;
        }
    }
}
