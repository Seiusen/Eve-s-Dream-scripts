using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerKeeperFinal : MonoBehaviour
{
    public Text dialogueTextKeeper;
    public Text nameTextKeeper;

    public GameObject dialogueMenuKeeper;

    private Queue<string> sentencesKeeper;

    public static bool dialogueStartedKeeperFinal;

    private void Start() 
    {
        dialogueStartedKeeperFinal = false;
        dialogueMenuKeeper.SetActive(false);
        sentencesKeeper = new Queue<string>();
    }


    public void StartDialogue(DialogueKeeper dialogueKeeper)
    {
        dialogueStartedKeeperFinal = true;
        dialogueMenuKeeper.SetActive(true);
        nameTextKeeper.text = dialogueKeeper.nameKeeper;
        sentencesKeeper.Clear();

        foreach (string sentenceKeeper in dialogueKeeper.sentencesKeeper)
        {
            sentencesKeeper.Enqueue(sentenceKeeper);
        }
        DisplayNextSentence(); 
    }

    public void DisplayNextSentence()
    {
        if(sentencesKeeper.Count == 0)
        {
            EndDialogue();
            DialodueColliderKeeperFinal.dialogueTriggerKeeperFinal = false;
            return;
        }
        string sentenceKeeper = sentencesKeeper.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceKeeper));
    }

    IEnumerator TypeSentence(string sentenceKeeper)
    {
        dialogueTextKeeper.text = "";
        foreach (char letter in sentenceKeeper.ToCharArray())
        {
            dialogueTextKeeper.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueMenuKeeper.SetActive(false);
        dialogueStartedKeeperFinal = false;
    }
}
