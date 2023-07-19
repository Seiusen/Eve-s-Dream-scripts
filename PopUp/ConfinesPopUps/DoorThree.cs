using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorThree : MonoBehaviour
{
    public GameObject DoorUI;
    public bool active;

    private void Start() 
    {
        DoorUI.SetActive(false);    
        active = false;
    }

    private void Update() 
    {
        if((Input.GetKeyDown(KeyCode.E)) & (active == true))
        {
            DoorUI.SetActive(false); 
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (DoorOpenHome.openned == false))
        {

            DoorUI.SetActive(true);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            DoorUI.SetActive(false); 
            active = false;
        }
    }
}
