using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifNine : MonoBehaviour
{
    public GameObject notification;

    private void Update() 
    {
        if (NotifTriggerNinth.ninthNot == true) 
        {
            notification.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
        }  
    }
}
