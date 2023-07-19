using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonnelBreak : MonoBehaviour
{
    public BoxCollider2D boxCol;
    public GameObject tilemapToDestroy;
    public GameObject selfDestruction;

    private void Awake() 
    {
        selfDestruction.SetActive(true);
    }

    private void Start() 
    {
        tilemapToDestroy.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitAndDestroy());
        }
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        tilemapToDestroy.SetActive(false);
        selfDestruction.SetActive(false);
    }
}
