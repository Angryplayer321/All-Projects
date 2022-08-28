using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
public class OnDialogueEvent : GameEvent
{
    public DialogueDataSO DialogueData;

    public OnDialogueEvent(DialogueDataSO _dialogueData)
    {
        DialogueData = _dialogueData;
    }
}
