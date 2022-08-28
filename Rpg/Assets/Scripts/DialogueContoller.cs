using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DynamicBox.EventManagement;

public class DialogueContoller : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private TMP_Text mainCharacterText;

    [SerializeField] private TMP_Text npcCharacterText;

    [SerializeField] private SpriteRenderer mainCharSprite;

    [SerializeField] private SpriteRenderer npcCharSprite;

    [Header("Params")]

    [Range(0f,1f)]
    [SerializeField] private float dialogueWriteDelay;


    #region Unity Methods

    private void OnEnable()
    {
        EventManager.Instance.AddListener<OnDialogueEvent>(OnDialogueEnterEventhandler);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnDialogueEvent>(OnDialogueEnterEventhandler);
    }

    #endregion

    #region Event Handlers

    private void OnDialogueEnterEventhandler(OnDialogueEvent eventDetails)
    {
        PlayDialogue(eventDetails.DialogueData);
    }

    #endregion


    public void PlayDialogue(DialogueDataSO dialogueData)
    {
        StartCoroutine(PlayDialogueCoroutine(dialogueData));
        Debug.Log("nese");
    }

    IEnumerator PlayDialogueCoroutine(DialogueDataSO dialogueData)
    {
        foreach(DialogueLine dialogueLine in dialogueData.dialogueLines)
        {
            dialogueText.text = "";

            if(dialogueLine.isMainCharacter)
            {
                mainCharacterText.gameObject.SetActive(true);

                npcCharacterText.gameObject.SetActive(false);

                mainCharacterText.text = dialogueLine.characterName;

            }
            else
            {
                mainCharacterText.gameObject.SetActive(false);

                npcCharacterText.gameObject.SetActive(true);

                npcCharacterText.text = dialogueLine.characterName;
            }
            for (int i = 0; i<dialogueLine.characterQuote.Length; i++)
            {
                dialogueText.text += dialogueLine.characterQuote[i];

                yield return new WaitForSeconds(dialogueWriteDelay);
            }

            yield return new WaitForSeconds(dialogueLine.dialogueDelay);
        }
    }
}
