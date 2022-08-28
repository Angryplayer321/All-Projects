using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewDialogueData", menuName = "ScriptableObjects/DialogueData")]

public class DialogueDataSO : ScriptableObject
{
    public DialogueLine[] dialogueLines;
  
}
[System.Serializable]

public class DialogueLine
{
    public string characterName;

    public AudioClip dialogueAudio;
    [TextArea(5,10)]
    public string characterQuote;

    public Sprite characterIcon;

    public bool isMainCharacter;

    public float dialogueDelay;


}