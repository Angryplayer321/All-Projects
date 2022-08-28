using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class LevelMechanics : MonoBehaviour
{
    private Color color;
    
    private int levelId = 0;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text correctLevelText;
    [SerializeField] private TMP_Text fieldText;
    [SerializeField] private GameObject correctMenu;
    [SerializeField] private GameObject gameplayMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelsMenu;
    private ArrayList questionList = new ArrayList()
    {
        "0",
        "1+1",
        "2+2",
        "2+2*2",
        "3-2+2*(1+3)",
        "3-4+5*(3-2-5)",
        "6+6",
        "7+7",
        "8+8",
        "9+9",
        "10+10"
    };
    private ArrayList answerList = new ArrayList()
    {
        "0",
        "2",
        "4",
        "6",
        "9",
        "-21",
        "12",
        "14",
        "16",
        "18",
        "20"
    };



    public void LevelSetter(int id)
    {
        levelId = id;
        questionText.text = "Question :" +questionList[levelId] +  " = ?";
        levelText.text = "Level :" + levelId.ToString();
            fieldText.color = Color.yellow; 
            fieldText.text = "Enter answer...";
        correctLevelText.text = levelText.text;
    }
    public void NextLevel()
    {

        LevelSetter(++levelId);
  
    }
    public void RestartLevel()
    {
        LevelSetter(levelId);
    }
    public void FieldFiller(int id)
    {
        if ((fieldText.text == "Enter answer...") || ("Wrong Answer!!!" == fieldText.text))
        {
            fieldText.color = Color.yellow;
            fieldText.text = "";
        }
        if (id >= 0)
            fieldText.text += id.ToString();
        else fieldText.text = fieldText.text.Remove(fieldText.text.Length - 1, 1);
        if (fieldText.text == "") fieldText.text = "Enter answer...";
    }

    public void Checker()
    {
        if (answerList[levelId].ToString() == fieldText.text)
        {
            gameplayMenu.SetActive(false);
            correctMenu.SetActive(true);
        }
        else
        {
            fieldText.color = Color.red;
            fieldText.text = "Wrong Answer!!!";
        }
    }
 



}
