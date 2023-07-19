using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifEight : MonoBehaviour
{
    public GameObject notificationOne;
    public GameObject notificationTwo;

    private void Update() 
    {
        if (NotifTriggerEighth.eighthNot == true) 
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
