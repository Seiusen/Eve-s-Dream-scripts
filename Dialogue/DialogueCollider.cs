using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollider : MonoBehaviour
{    
    public static bool dialogueTrigger;

    public Dialogue dialogue;
    public DialogueManager dm;

    public GameObject dialoguePreview;

    private void Start() 
    {
        dialogueTrigger = false;  
        dialoguePreview.SetActive(false);  
    }

    private void Update() 
    {
        if((dialogueTrigger == true) & (Input.GetKeyDown(KeyCode.E)) & (DialogueManager.dialogueStared == false))
        {
            TriggerDialogue();
        }
        else if ((dialogueTrigger == true) & (Input.GetKeyDown(KeyCode.E)))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence(); 
        }    
    }

    public void TriggerDialogue()
    {
        dialoguePreview.SetActive(false); 
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            dialogueTrigger = true;
            dialoguePreview.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            dialogueTrigger = false;
            dialoguePreview.SetActive(false);
            dm.EndDialogue();
        }
    }
}
