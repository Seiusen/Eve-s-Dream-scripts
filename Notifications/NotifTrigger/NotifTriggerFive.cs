using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerFive : MonoBehaviour
{
    public static bool fifthNot;

    private void Start() 
    {
        fifthNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            fifthNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            fifthNot = false;
        }
    }
}
