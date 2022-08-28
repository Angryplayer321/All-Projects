using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class WinViewController : MonoBehaviour
{
    [SerializeField] WinView winView;

    [SerializeField] GameObject winPanel;


    private void OnEnable()
    {
        EventManager.
            Instance.AddListener<PlayerWinEvent>(PlayerWinEventHandler);
    }

    private void OnDisable()
    {
        EventManager.
            Instance.RemoveListener<PlayerWinEvent>(PlayerWinEventHandler);
    }
    public void PlayerWinEventHandler(PlayerWinEvent WinEvent)
    {
        winPanel.SetActive(true);
    }

    public void OnRetryButton()
    {
        winPanel.SetActive(false);

        EventManager.Instance.Raise(new ResetGameEvent());

        
    }
}
