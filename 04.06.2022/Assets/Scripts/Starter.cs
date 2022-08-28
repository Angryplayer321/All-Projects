using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private GameObject correctMenu;
    [SerializeField] private GameObject gameplayMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelsMenu;

    void Start()
    {
        levelsMenu.SetActive(false);
        gameplayMenu.SetActive(false);
        correctMenu.SetActive(false);
        mainMenu.SetActive(true);
        Debug.Log("niye ?");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
