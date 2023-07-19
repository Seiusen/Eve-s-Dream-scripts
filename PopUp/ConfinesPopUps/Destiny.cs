using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destiny : MonoBehaviour
{
    public GameObject DestinyUI;
    public bool active;
    public bool wasUsed;

    private void Start() 
    {
        DestinyUI.SetActive(false);    
        active = false;
        wasUsed = false;
    }

    private void Update() 
    {
        if((Input.GetKeyDown(KeyCode.E)) & (active == true) & (wasUsed == false))
        {
            DestinyUI.SetActive(false); 
            wasUsed = true;
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (wasUsed == false))
        {
            DestinyUI.SetActive(true);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            DestinyUI.SetActive(false); 
            active = false;
        }
    }
}
