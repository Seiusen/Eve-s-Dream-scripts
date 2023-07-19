using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifOne : MonoBehaviour
{
    public GameObject notification;
    public GameObject notification1;

    private void Update() 
    {
        if (NotifTriggerOne.firstNot == true) 
        {
            notification.SetActive(true);
            notification1.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
            notification1.SetActive(false);
        }  
    }
}
