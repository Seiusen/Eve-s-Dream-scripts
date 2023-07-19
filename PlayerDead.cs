using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public int levelToLoad;

    private void Update() 
    {
        if(Health.hp == 0)
        {
            SceneManager.LoadScene(levelToLoad);
            Health.hp = 100;
            Food.food = 100;
            Water.water = 100;
            Stamina.stamina = 100;
            Player_move.destinyGained = false;
        }

        if(Water.water == 0)
        {
            SceneManager.LoadScene(levelToLoad);
            Health.hp = 100;
            Food.food = 100;
            Water.water = 100;
            Stamina.stamina = 100;
            Player_move.destinyGained = false;
        }

        if(Food.food == 0)
        {
            SceneManager.LoadScene(levelToLoad);
            Health.hp = 100;
            Food.food = 100;
            Water.water = 100;
            Stamina.stamina = 100;
            Player_move.destinyGained = false;
        }
    }
}
