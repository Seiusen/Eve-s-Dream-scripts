using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public static float stamina;
    public float maxStamina = 100;
    public float reductionStamina = 5;

    [SerializeField] Image staminaInner;

    private void Start() 
    {
        staminaInner = GetComponent<Image>();
        stamina = 100;
        staminaInner.fillAmount = stamina / maxStamina;
    }

    private void Update() 
    {
        StaminaOut();
        StaminaCount();
    }

    private void StaminaOut()
    {
        if (stamina > 100)
        {
            stamina = 100;
            staminaInner.fillAmount = maxStamina / maxStamina;
        }
        else if ((stamina < 100) & (stamina > 0))
        {
            staminaInner.fillAmount = stamina / maxStamina;
        }
        else if (stamina <= 1)
        {
            stamina = 0;
        }
    }

    private void StaminaCount()
    {
        if (Player_move.running == true)
        {
            stamina -= reductionStamina * 2 * Time.deltaTime /** 6*/;
        }
        else if (Player_move.running == false)
        {
            StartCoroutine(CDCoroutine());
            stamina += reductionStamina * Time.deltaTime * 4/** 3*/;
        }
    }

    IEnumerator CDCoroutine()
    {
        yield return new WaitForSeconds(2f);
    }

}
