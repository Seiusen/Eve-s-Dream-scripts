using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueColliderKeeper : MonoBehaviour
{
    public static bool dialogueTriggerKeeper;

    public DialogueKeeper dialogueKeeper;
    public DialogueManagerKeeper dmKeeper;

    public GameObject dialoguePreviewKeeper;

    private void Start() 
    {
        dialogueTriggerKeeper = false;  
        dialoguePreviewKeeper.SetActive(false);  
    }

    private void Update() 
    {
        if((dialogueTriggerKeeper == true) & (Input.GetKeyDown(KeyCode.E)) & (DialogueManagerKeeper.dialogueStaredKeeper == false))
        {
            TriggerDialogue();
        }
        else if ((dialogueTriggerKeeper == true) & (Input.GetKeyDown(KeyCode.E)))
        {
            FindObjectOfType<DialogueManagerKeeper>().DisplayNextSentence(); 
        }    
    }

    public void TriggerDialogue()
    {
        dialoguePreviewKeeper.SetActive(false); 
        FindObjectOfType<DialogueManagerKeeper>().StartDialogue(dialogueKeeper);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (Player_move.destinyGained == false))
        {
            dialogueTriggerKeeper = true;
            dialoguePreviewKeeper.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (Player_move.destinyGained == false))
        {
            dialogueTriggerKeeper = false;
            dialoguePreviewKeeper.SetActive(false);
            dmKeeper.EndDialogue();
        }
    }
}
