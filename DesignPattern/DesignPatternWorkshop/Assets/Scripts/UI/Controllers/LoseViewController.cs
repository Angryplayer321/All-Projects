using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class LoseViewController : MonoBehaviour
{
    [SerializeField] LoseView loseView;

    [SerializeField] GameObject losePanel;
    private void OnEnable()
    {
        EventManager.
            Instance.AddListener<PlayerLoseEvent>(PlayerLoseEventHandler);
    }

    private void OnDisable()
    {
        EventManager.
            Instance.RemoveListener<PlayerLoseEvent>(PlayerLoseEventHandler);
    }
   public void PlayerLoseEventHandler(PlayerLoseEvent loseEvent)
    {
        losePanel.SetActive(true);
    }

    public void OnRetryButton()
    {
        losePanel.SetActive(false);

        EventManager.Instance.Raise(new ResetGameEvent());

       // Time.timeScale = 1;
    }
}
