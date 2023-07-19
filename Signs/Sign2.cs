using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign2 : MonoBehaviour
{
    public GameObject Sign;

    private void Start() 
    {
        Sign.SetActive(false);    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {

            Sign.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Sign.SetActive(false); 
        }
    }
}
