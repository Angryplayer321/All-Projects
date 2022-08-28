using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.SaveManagement;

public class PlayerDataController : MonoBehaviour
{
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = new SaveManager(StorageMethod.JSON);
        Debug.Log(Application.persistentDataPath);
    }

    public void SaveDataInStorage()
    {
        PlayerData playerData = new PlayerData("Valadorf", 100, 20);
        saveManager.SaveToFile<PlayerData>(playerData, "PlayerDataJson");
    }
    public void ChangeDataInStorage()
    {
        PlayerData playerData = saveManager.LoadFromFile<PlayerData>("PlayerDataJson", new PlayerData("Valadorf", 100, 20));

        playerData.playerHealth = 80;

        playerData.playerNickName = "Egzy";
        saveManager.SaveToFile<PlayerData>(playerData, "PlayerDataJson");
    }


}
