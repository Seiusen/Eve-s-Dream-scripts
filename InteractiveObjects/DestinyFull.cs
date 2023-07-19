using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinyFull : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    public bool nearDestiny;

    public bool wasRestored;
    

    private void Start() 
    {
        nearDestiny = false;
        boxCol = GetComponent<BoxCollider2D>();
        wasRestored = false;
    }

    private void Update() 
    {
        if(wasRestored == false)
        {
            DestinyFiller();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearDestiny = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearDestiny = false;
        }
    }

    private void DestinyFiller()
    {
        if ((nearDestiny == true) & (Input.GetKeyDown(KeyCode.E)) & (wasRestored == false))
        {
            wasRestored = true;
            Food.food = 100;
            Water.water = 100;
        }
    }
}
