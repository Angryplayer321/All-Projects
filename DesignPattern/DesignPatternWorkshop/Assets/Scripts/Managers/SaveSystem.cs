using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.SaveManagement;

public class SaveSystem : MonoBehaviour
{

    [SerializeField] private string dummyNickName;

    [SerializeField] private int dummyHealth;

    [SerializeField] private int dummyExp;

    [SerializeField] private string playerDataFileName = "PlayerData";

    private SaveManager saveMgr;


    private void Awake()
    {
        saveMgr = new SaveManager(StorageMethod.JSON);
    }

    private void Start()
    {

        PlayerData newPlayerData = new PlayerData(dummyNickName, dummyNickName, dummyHealth, dummyExp);

        if(saveMgr.FileExists(playerDataFileName))
        {
            PlayerData data = saveMgr.LoadFromFile<PlayerData>(playerDataFileName,null);

            print(data.playerNickName);

            print(data.playerName);

            print(data.playerHealth);

            print(data.playerExp);
        }
        


        saveMgr.SaveToFile<PlayerData>(newPlayerData,playerDataFileName);

        print(Application.persistentDataPath);
    }
}
