using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifSeven : MonoBehaviour
{
    public GameObject notification;

    private void Update() 
    {
        if (NotifTriggerSeventh.seventhNot == true) 
        {
            notification.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
        }  
    }
}