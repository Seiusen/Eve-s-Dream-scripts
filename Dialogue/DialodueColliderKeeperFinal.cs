using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialodueColliderKeeperFinal : MonoBehaviour
{
    public static bool dialogueTriggerKeeperFinal;

    public DialogueKeeper dialogueKeeper;
    public DialogueManagerKeeperFinal dmKeeperFinal;

    public GameObject dialoguePreviewKeeper;

    private void Start() 
    {
        dialogueTriggerKeeperFinal = false;  
        dialoguePreviewKeeper.SetActive(false);  
    }

    private void Update() 
    {
        if((dialogueTriggerKeeperFinal == true) & (Input.GetKeyDown(KeyCode.E)) & (DialogueManagerKeeperFinal.dialogueStartedKeeperFinal == false))
        {
            TriggerDialogue();
        }
        else if ((dialogueTriggerKeeperFinal == true) & (Input.GetKeyDown(KeyCode.E)))
        {
            FindObjectOfType<DialogueManagerKeeperFinal>().DisplayNextSentence(); 
        }    
    }

    public void TriggerDialogue()
    {
        dialoguePreviewKeeper.SetActive(false); 
        FindObjectOfType<DialogueManagerKeeperFinal>().StartDialogue(dialogueKeeper);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (Player_move.destinyGained == true))
        {
            dialogueTriggerKeeperFinal = true;
            dialoguePreviewKeeper.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player") & (Player_move.destinyGained == true))
        {
            dialogueTriggerKeeperFinal = false;
            dialoguePreviewKeeper.SetActive(false);
            dmKeeperFinal.EndDialogue();
        }
    }
}
