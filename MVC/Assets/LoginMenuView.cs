using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoginMenuView : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private LoginMenuController controller;

    [Header("View Elements")]
    [SerializeField] private TMP_InputField userNameInputField;

    [SerializeField] private TMP_InputField userPassInputField;

    [SerializeField] private Button loginButton;

    [SerializeField] private TMP_Text loginFailedText;

    [SerializeField] private TMP_Text loginSuccessText;

    public void OnUserNameInputFieldChanged(string input)
    {
        if(string.IsNullOrEmpty(input) || string.IsNullOrEmpty(userPassInputField.text))
        {
            loginButton.interactable = false;

            Debug.Log("Username or password field is empty");

            return;
        }

        else if (input.Length<10 || userPassInputField.text.Length < 10 )
        {
            loginButton.interactable = false;

            Debug.Log("Username or password is weak");

            return;
        }

        loginButton.interactable = true;
    }


    public void OnUserPassInputFieldChanged(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(userNameInputField.text))
        {
            loginButton.interactable = false;

            Debug.Log("Username or password field is empty");

            return;
        }

        else if (input.Length < 10 || userNameInputField.text.Length < 10)
        {
            loginButton.interactable = false;

            Debug.Log("Username or password is weak");

            return;
        }

        loginButton.interactable = true;
    }

    public void OnLoginButtonPressed()
    {
        controller.OnLoginButtonPressed(userNameInputField.text, userPassInputField.text);

    }

    public IEnumerator LoginFailedCoroutine()
    {
        loginFailedText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        loginFailedText.gameObject.SetActive(false);
    }

    public IEnumerator LoginSuccessCoroutine()
    {
        loginSuccessText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        loginSuccessText.gameObject.SetActive(false);
    }
}
