using System.Collections;
using System.Collections.Generic;

public class PlayerData 
{
    public string playerNickName;

    public int playerHealth;

    public int playerXp;

    public int playerLever;

    private int playerDamage;

    public PlayerData(string _playerNick, int _playerHlth, int _playerDmg )
    {
        playerNickName = _playerNick;
        playerHealth = _playerHlth;
        playerDamage = _playerDmg;
    }

  
}
