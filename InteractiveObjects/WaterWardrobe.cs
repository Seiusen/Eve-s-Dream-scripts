using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWardrobe : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    public bool nearWardrobeWater;

    public float waterRestore;
    float[] waterRestoreArray;
    public bool wasRestored;
    

    private void Start() 
    {
        nearWardrobeWater = false;
        boxCol = GetComponent<BoxCollider2D>();
        waterRestoreArray = new float[5] { 10, 15, 20, 25, 30 };
        wasRestored = false;
    }

    private void Update() 
    {
        if(wasRestored == false)
        {
            WardrobeWaterFiller();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearWardrobeWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearWardrobeWater = false;
        }
    }

    private void WardrobeWaterFiller()
    {
        if ((nearWardrobeWater == true) & (Input.GetKeyDown(KeyCode.E)) & (wasRestored == false))
        {
            wasRestored = true;
            waterRestore = waterRestoreArray[Random.Range(0, waterRestoreArray.Length)];
            Water.water += waterRestore;
        }
    }
}
