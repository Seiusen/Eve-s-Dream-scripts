using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifFive : MonoBehaviour
{
    public GameObject notification;

    private void Update() 
    {
        if (NotifTriggerFive.fifthNot == true) 
        {
            notification.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
        }  
    }
}
