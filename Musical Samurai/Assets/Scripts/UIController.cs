using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject levelsMenu;
    [SerializeField] PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
        levelsMenu.SetActive(false);
    }
    public void StartButton()
    {
        startMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    public void BackButton()
    {
        startMenu.SetActive(true);
        levelsMenu.SetActive(false);
    }

    public void Levels(int levelNumber)
    {
        SceneManager.LoadScene("SampleScene");
        PlayerMovement.isPlaying = true;
        Debug.Log("Level scene is loaded!");
    }
}
