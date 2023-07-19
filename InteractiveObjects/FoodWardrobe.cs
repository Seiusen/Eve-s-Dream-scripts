using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWardrobe : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    public bool nearWardrobeFood;

    public float foodRestore;
    float[] foodRestoreArray;
    public bool wasRestored;
    

    private void Start() 
    {
        nearWardrobeFood = false;
        boxCol = GetComponent<BoxCollider2D>();
        foodRestoreArray = new float[5] { 10, 15, 20, 25, 30 };
        wasRestored = false;
    }

    private void Update() 
    {
        if(wasRestored == false)
        {
            WardrobeFoodFiller();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearWardrobeFood = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            nearWardrobeFood = false;
        }
    }

    private void WardrobeFoodFiller()
    {
        if ((nearWardrobeFood == true) & (Input.GetKeyDown(KeyCode.E)) & (wasRestored == false))
        {
            wasRestored = true;
            foodRestore = foodRestoreArray[Random.Range(0, foodRestoreArray.Length)];
            Food.food += foodRestore;
        }
    }
}
