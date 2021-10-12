using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MainUi : MonoBehaviour
{
    [SerializeField]
    private int money;  // Total Money
    public TMP_Text moneytext;
    public float playerSpeed;
    private int speedLevel;
    private int gameLevel;
    public TMP_Text speedUpgradeText;
    public TMP_Text levelUpgradeText;
    void Start()
    {
         if (PlayerPrefs.HasKey("Money"))
         {
              
         }
         else
         {
            PlayerPrefs.SetInt("Money",0);
         };
          if (PlayerPrefs.HasKey("speedLevel"))
         {
              
         }
         else
         {
            PlayerPrefs.SetInt("speedLevel",1);
         };
         if (PlayerPrefs.HasKey("PlayerSpeed"))
         {
              
         }
         else
         {
            PlayerPrefs.SetFloat("PlayerSpeed",2f);
         };
         if (PlayerPrefs.HasKey("GameLevel"))
         {
              
         }
         else
         {
            PlayerPrefs.SetInt("GameLevel",1);
         };
         money = PlayerPrefs.GetInt("Money");
         playerSpeed = PlayerPrefs.GetFloat("PlayerSpeed");
         speedLevel = PlayerPrefs.GetInt("speedLevel");
         gameLevel = PlayerPrefs.GetInt("GameLevel");
         moneytext.text = money + "";
         DisplayUpgradeSpeed();
         DisplayGameLevel();
    }

    public void IncreaseSpeed()
    {
        if(money >= 1000)
        {
             playerSpeed += 0.1f;
             PlayerPrefs.SetFloat("PlayerSpeed",playerSpeed);
             money -= 1000;
             PlayerPrefs.SetInt("Money",money);
             moneytext.text = money + "";
             UpgradeSpeedLvl();
        }
    }

    public void UpgradeSpeedLvl()
    {
         speedLevel =  PlayerPrefs.GetInt("speedLevel");
         speedLevel += 1;
         PlayerPrefs.SetInt("speedLevel",speedLevel);
         DisplayUpgradeSpeed();
    }

    public void DisplayUpgradeSpeed()
    {
         speedUpgradeText.text = "LVL "+ speedLevel;
    }

    public void DisplayGameLevel()
    {
         gameLevel = PlayerPrefs.GetInt("GameLevel");
         levelUpgradeText.text = "LEVEL "+ gameLevel;
    }
    
    public void StartCurrentLevel()
    {
         SceneManager.LoadScene(PlayerPrefs.GetInt("GameLevel"));
    }
}
