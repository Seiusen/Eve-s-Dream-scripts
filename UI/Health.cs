using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static float hp;
    public static float maxHp = 100;
    public float hpDifference;

    [SerializeField] Image hpInner;

    private void Start() 
    {
        hpInner = GetComponent<Image>();
        if (hp == 0)
        {
            hp = 100;
        }
        hpInner.fillAmount = maxHp / maxHp;
    }

    private void Update() 
    {
        MedicHeal();
        GettingDamage();
        HealthCount();
    }

    private void HealthCount()
    {
        if (hp > 100)
        {
            hp = 100;
            hpInner.fillAmount = maxHp / maxHp;
        }
        else if ((hp < 100) & (hp > 0))
        {
            hpInner.fillAmount = hp / maxHp;
        }
        else if (hp <= 0)
        {
            hp = 0;
        }
        hpInner.fillAmount = hp / maxHp;
    }

    private void MedicHeal()
    {
        if ((Medic.nearMedic == true) & (Input.GetKeyDown(KeyCode.E)))
        {
            hp = 100;
            hpInner.fillAmount = hp / maxHp;
        }
    }

    private void GettingDamage()
    {
        if (Player_move.damage != 0)
        {
            hp -= Player_move.damage;
            Player_move.damage = 0;
            hpInner.fillAmount = hp / maxHp;
            Player_move.damaged = false;
        }
    }

}
