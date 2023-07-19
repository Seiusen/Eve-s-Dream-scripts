using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DialogueKeeper 
{
    public string nameKeeper;
    [TextArea(3, 20)]
    public string[] sentencesKeeper;
}