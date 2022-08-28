using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteChecker : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private bool isC;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isC && Input.GetKeyDown(KeyCode.C))
            gameObject.SetActive(false);
        else if (!isC && Input.GetKeyDown(KeyCode.X))
            gameObject.SetActive(false);
        Debug.Log("Heri");
    }
}
