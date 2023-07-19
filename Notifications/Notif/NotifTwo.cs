using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTwo : MonoBehaviour
{
    public GameObject notification;

    private void Update() 
    {
        if (NotifTriggerTwo.secondNot == true) 
        {
            notification.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
        }  
    }
}
