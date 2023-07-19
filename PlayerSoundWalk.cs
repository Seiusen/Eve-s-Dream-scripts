using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundWalk : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource run;

    void Update()
    {
        if ((Input.GetKey(KeyCode.D)) & (Input.GetKey(KeyCode.A)))
        {
            walk.Stop();
            run.Stop();
        }
        else if ((Input.GetKeyDown(KeyCode.LeftShift)) & ((Input.GetKey(KeyCode.A)) | (Input.GetKey(KeyCode.D))))
        {
            walk.Stop();
            run.Play();
        }
        else if ((Input.GetKey(KeyCode.LeftShift)) & ((Input.GetKeyDown(KeyCode.A)) | (Input.GetKeyDown(KeyCode.D))))
        {
            run.Play();
        }
        else if ((Input.GetKeyDown(KeyCode.D)) | (Input.GetKeyDown(KeyCode.A)))
        {
            run.Stop();
            walk.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) & ((Input.GetKey(KeyCode.D)) | (Input.GetKey(KeyCode.A))))
        {
            run.Stop();
            walk.Play();
        }
        else if((Input.GetKeyUp(KeyCode.D)) | (Input.GetKeyUp(KeyCode.A)))
        {
            walk.Stop();
            run.Stop();
            if(Input.GetKey(KeyCode.LeftShift) & ((Input.GetKey(KeyCode.D)) | (Input.GetKey(KeyCode.A))))
            {
                run.Play();
            }
            else if((Input.GetKey(KeyCode.D)) | (Input.GetKey(KeyCode.A)))
            {
                walk.Play();
            }
        }
    }
}
