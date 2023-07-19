using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockers : MonoBehaviour
{
    public GameObject LockerUI;
    public bool active;
    public bool wasUsed;

    private void Start() 
    {
        LockerUI.SetActive(false);    
        active = false;
        wasUsed = false;
    }

    private void Update() 
    {
        if((Input.GetKeyDown(KeyCode.E)) & (active == true) & (wasUsed == false))
        {
            LockerUI.SetActive(false); 
            wasUsed = true;
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (wasUsed == false))
        {
            LockerUI.SetActive(true);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            LockerUI.SetActive(false); 
            active = false;
        }
    }
}
