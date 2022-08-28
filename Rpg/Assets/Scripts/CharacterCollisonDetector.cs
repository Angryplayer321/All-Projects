using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class CharacterCollisonDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DialogueNPC"))
        {
            DialogueDataSO npcDialogueData =
                other.GetComponent<NPCDialogueHolder>().ReturnDialogueData();

            EventManager.Instance.Raise(new OnDialogueEvent(npcDialogueData));

            other.GetComponent<Collider>().enabled = false;
        }
        

    }
    
}
