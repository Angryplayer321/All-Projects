using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;


public class LoginMenuController : MonoBehaviour
{
    [SerializeField] private LoginMenuView view;


    public void OnLoginButtonPressed(string userName, string userPass)
    {
        EventManager.Instance.Raise(new OnLoginButtonPressedEvent(userName, userPass));
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnLoginFailedEvent>(OnLoginFailedEventHandler);
        EventManager.Instance.RemoveListener<OnLoginSuccessEvent>(OnLoginSuccessEventHandler);

    }


    private void OnEnable()
    {
        EventManager.Instance.AddListener<OnLoginFailedEvent>(OnLoginFailedEventHandler);
        EventManager.Instance.AddListener<OnLoginSuccessEvent>(OnLoginSuccessEventHandler);
    }

    private void OnLoginFailedEventHandler(OnLoginFailedEvent eventDetails)
    {
        StartCoroutine(view.LoginFailedCoroutine());
    }

    private void OnLoginSuccessEventHandler(OnLoginSuccessEvent eventDetails)
    {
        StartCoroutine(view.LoginSuccessCoroutine());
    }
}


