using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTriggerThree : MonoBehaviour
{
    public static bool thirdNot;

    private void Start() 
    {
        thirdNot = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            thirdNot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            thirdNot = false;
        }
    }
}
