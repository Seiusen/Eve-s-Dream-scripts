using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpCol3 : MonoBehaviour
{
    public GameObject UI;
    public bool active;

    private void Start() 
    {
        UI.SetActive(false);    
        active = false;
    }

    private void Update() 
    {
        if((Input.GetKeyDown(KeyCode.E)) & (active == true))
        {
            UI.SetActive(false); 
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {

            UI.SetActive(true);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            UI.SetActive(false); 
            active = false;
        }
    }
}
