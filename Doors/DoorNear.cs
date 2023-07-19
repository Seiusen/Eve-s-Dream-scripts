using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNear : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    public static bool nearDoorHome;

    private void Start() 
    {
        nearDoorHome = false;
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearDoorHome = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearDoorHome = false;
        }
    }
}
