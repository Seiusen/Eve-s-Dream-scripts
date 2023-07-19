using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;

    public GameObject dialogueMenu;

    private Queue<string> sentences;

    public static bool dialogueStared;

    private void Start() 
    {
        dialogueStared = false;
        dialogueMenu.SetActive(false);
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        dialogueStared = true;
        dialogueMenu.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(); 
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            DialogueCollider.dialogueTrigger = false;
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueMenu.SetActive(false);
        dialogueStared = false;
    }
}
