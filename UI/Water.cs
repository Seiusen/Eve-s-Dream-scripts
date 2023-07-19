using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public static float maxWater = 100;
    public static float water;
    public float waterReduction;
    float[] walkingArray;
    float[] runningArray;
    float[] gravityArray;

    [SerializeField] Image waterInner;

    private void Start() {
        waterInner = GetComponent<Image>();
        walkingArray = new float[2] { 1, 2 };
        runningArray = new float[3] { 3, 4, 5 };
        gravityArray = new float[3] { 0.2f, 0.4f, 0.6f };
        if (water == 0)
        {
            water = 100;
        }
        waterInner.fillAmount = water / maxWater;
    }

    private void Update() 
    {
        WaterOut();
        WaterCount();
        CookWaterFiller();
        KitchenFiller();
    }

    private void WaterOut()
    {
        if (water > 100)
        {
            water = 100;
            waterInner.fillAmount = maxWater / maxWater;
        }
        else if ((water < 100) & (water > 0))
        {
            waterInner.fillAmount = water / maxWater;
        }
        else if (water <= 0)
        {
            water = 0;
        }
    }

    private void WaterCount()
    {
        if (Player_move.walking == true)
        {
            waterReduction = walkingArray[Random.Range(0, walkingArray.Length)];
            water -= waterReduction * Time.deltaTime / 10;
        }   

        if (Player_move.running == true)
        {
            waterReduction = runningArray[Random.Range(0, runningArray.Length)];
            water -= waterReduction * Time.deltaTime / 10;
        }

        if (Player_move.gravityChangedWater == true)
        {
            waterReduction = gravityArray[Random.Range(0, gravityArray.Length)];
            water -= waterReduction;
            Player_move.gravityChangedWater = false;
        }
    }

    private void CookWaterFiller()
    {
        if ((CookWater.nearCookWater == true) & (Input.GetKeyDown(KeyCode.E)))
        {
            water = 100;
            waterInner.fillAmount = water / maxWater;
        }
    }

    private void KitchenFiller()
    {
        if ((Kitchen.nearKitchen== true) & (Input.GetKeyDown(KeyCode.E)))
        {
            water = 100;
            waterInner.fillAmount = water / maxWater;
        }
    }
}
