using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinyFinal : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    public GameObject DestinyUI;
    public static bool destiny;

    private void Awake() 
    {
        destiny = false;
    }

    private void Start() 
    {
        boxCol = GetComponent<BoxCollider2D>();
        DestinyUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            DestinyUI.SetActive(true);
            destiny = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            DestinyUI.SetActive(false);
        }
    }

}
