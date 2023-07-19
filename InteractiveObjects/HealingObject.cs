using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    public bool nearHealingObject;

    public float healthRestore;
    float[] healthRestoreArray;
    public bool wasRestored;
    

    private void Start() 
    {
        nearHealingObject = false;
        boxCol = GetComponent<BoxCollider2D>();
        healthRestoreArray = new float[4] { 5, 10, 15, 20 };
        wasRestored = false;
    }

    private void Update() 
    {
        if(wasRestored == false)
        {
            Healing();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearHealingObject = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearHealingObject = false;
        }
    }

    private void Healing()
    {
        if ((nearHealingObject == true) & (Input.GetKeyDown(KeyCode.E)) & (wasRestored == false))
        {
            wasRestored = true;
            healthRestore = healthRestoreArray[Random.Range(0, healthRestoreArray.Length)];
            Health.hp += healthRestore;
        }
    }
}
