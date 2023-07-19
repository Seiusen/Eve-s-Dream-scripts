using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerNinth : MonoBehaviour
{
    public static bool ninthNot;

    private void Start() 
    {
        ninthNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            ninthNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            ninthNot = false;
        }
    }
}
