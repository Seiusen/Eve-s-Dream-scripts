using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifThree : MonoBehaviour
{
    public GameObject notification;

    private void Update() 
    {
        if (NotifTriggerThree.thirdNot == true) 
        {
            notification.SetActive(true);
        } 
        else
        {
            notification.SetActive(false);
        }  
    }
}
