using DynamicBox.EventManagement;

public class OnLoginButtonPressedEvent : GameEvent
{ 
    public string UserName;

    public string UserPass;

    public OnLoginButtonPressedEvent(string _userName, string _userPass)
    {
        UserName = _userName;

        UserPass = _userPass;
    }
}
