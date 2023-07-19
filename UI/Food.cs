using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public static float maxFood = 100;
    public static float food;
    public float foodReduction;
    float[] walkingArray;
    float[] runningArray;
    float[] gravityArray;

    [SerializeField] Image foodInner;

    private void Start() {
        foodInner = GetComponent<Image>();
        walkingArray = new float[2] { 1, 2 };
        runningArray = new float[3] { 3, 4, 5 };
        gravityArray = new float[3] { 0.25f, 0.5f, 0.8f };
        if (food == 0)
        {
            food = 100;
        }
        foodInner.fillAmount = food / maxFood;
    }

    private void Update() 
    {
        FoodOut();
        FoodCount();
        CookFoodFiller();
        KitchenFiller();
    }

    private void FoodOut()
    {
        if (food > 100)
        {
            food = 100;
            foodInner.fillAmount = maxFood / maxFood;
        }
        else if ((food < 100) & (food > 0))
        {
            foodInner.fillAmount = food / maxFood;
        }
        else if (food <= 0)
        {
            food = 0;
        }
    }

    private void FoodCount()
    {
        if (Player_move.walking == true)
        {
            foodReduction = walkingArray[Random.Range(0, walkingArray.Length)];
            food -= foodReduction * Time.deltaTime / 30;
        }   

        if (Player_move.running == true)
        {
            foodReduction = runningArray[Random.Range(0, runningArray.Length)];
            food -= foodReduction * Time.deltaTime / 30;
        }

        if (Player_move.gravityChangedFood == true)
        {
            foodReduction = gravityArray[Random.Range(0, gravityArray.Length)];
            food -= foodReduction;
            Player_move.gravityChangedFood = false;
        }
    }

    private void CookFoodFiller()
    {
        if ((CookFood.nearCookFood == true) & (Input.GetKeyDown(KeyCode.E)))
        {
            food = 100;
            foodInner.fillAmount = food / maxFood;
        }
    }

    private void KitchenFiller()
    {
        if ((Kitchen.nearKitchen== true) & (Input.GetKeyDown(KeyCode.E)))
        {
            food = 100;
            foodInner.fillAmount = food / maxFood;
        }
    }
}
