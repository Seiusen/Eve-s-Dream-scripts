using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifSix : MonoBehaviour
{
    public GameObject notification;

    private void Update() 
    {
        if (NotifTriggerSix.sixthNot == true) 
        {
            notification.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
        }  
    }
}
