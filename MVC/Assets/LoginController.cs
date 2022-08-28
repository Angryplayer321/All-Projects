using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class LoginController : MonoBehaviour
{
    [SerializeField] private string realUserName;

    [SerializeField] private string realUserPass;

    private void OnEnable()
    {
        EventManager.Instance.AddListener<OnLoginButtonPressedEvent>(OnLoginButtonPressedEventHandler);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnLoginButtonPressedEvent>(OnLoginButtonPressedEventHandler);
    }


    private void OnLoginButtonPressedEventHandler(OnLoginButtonPressedEvent eventDetails)
    {
        if(eventDetails.UserName != realUserName || eventDetails.UserPass != realUserPass)
        {
            EventManager.Instance.Raise(new OnLoginFailedEvent());
            Debug.Log("Incorrect username or password");
            return;
        }

        EventManager.Instance.Raise(new OnLoginSuccessEvent());
        Debug.Log("Logged in succesfully");

    }

}
