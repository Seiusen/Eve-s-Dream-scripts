using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAudio : MonoBehaviour
{
    public BoxCollider2D boxCol;
    public AudioSource sound;

    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        sound = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            sound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            sound.Stop();
        }
    }
}
