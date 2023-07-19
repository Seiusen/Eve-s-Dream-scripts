using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifTen : MonoBehaviour
{
    public GameObject notificationOne;
    public GameObject notificationTwo;

    private void Update() 
    {
        if (NotifTriggerTenth.tenthNot == true) 
        {
            notificationOne.SetActive(true);
            notificationTwo.SetActive(true);
        } 
        else
        {
            notificationOne.SetActive(false);
            notificationTwo.SetActive(false);
        }  
    }
}
