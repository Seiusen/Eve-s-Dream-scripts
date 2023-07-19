using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifFour : MonoBehaviour
{
    public GameObject notification;

    private void Update() 
    {
        if (NotifTriggerFour.fourthNot == true) 
        {
            notification.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
        }  
    }
}
