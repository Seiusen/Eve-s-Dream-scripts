using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenHome : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol;
    [SerializeField] SpriteRenderer sr;
    public static bool openned;
    
    private void Start() 
    {
        boxCol = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        openned = false;
    }

    private void Update() 
    {
        if ((DoorNear.nearDoorHome == true) & (Input.GetKeyDown(KeyCode.E)))
        {
            boxCol.enabled = false;
            sr.enabled = false;
            openned = true;
        }
        else if (DoorNear.nearDoorHome == false)
        {
            boxCol.enabled = true;
            sr.enabled = true;
            openned = false;
        }
    }
}
