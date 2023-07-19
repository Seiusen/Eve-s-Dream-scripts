using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpennedDoor : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    
    void Update()
    {
        if (DoorOpenHome.openned == true)
        {
            sr.enabled = true;
        }
        else if (DoorOpenHome.openned == false)
        {
            sr.enabled = false;
        }
    }
}
