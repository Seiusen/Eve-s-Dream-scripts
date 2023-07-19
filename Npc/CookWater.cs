using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookWater : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    public static bool nearCookWater;

    private void Start() 
    {
        nearCookWater = false;
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearCookWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearCookWater = false;
        }
    }
}
