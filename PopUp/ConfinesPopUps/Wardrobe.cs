using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public GameObject WardrobeUI;
    public bool active;
    public bool wasUsed;

    private void Start() 
    {
        WardrobeUI.SetActive(false);    
        active = false;
        wasUsed = false;
    }

    private void Update() 
    {
        if((Input.GetKeyDown(KeyCode.E)) & (active == true) & (wasUsed == false))
        {
            WardrobeUI.SetActive(false); 
            wasUsed = true;
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (wasUsed == false))
        {
            WardrobeUI.SetActive(true);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            WardrobeUI.SetActive(false); 
            active = false;
        }
    }
}
