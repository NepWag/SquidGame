using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private int money;
    private int randomMoney;
    public TMP_Text moneytext;
    public TMP_Text currentmoneytext;
    public static MoneyManager instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
         {
              
         }
         else
         {
            PlayerPrefs.SetInt("Money",0);
         };
         money = PlayerPrefs.GetInt("Money");
         moneytext.text = money + "";
    }

    public void AddMoney()
    {
        randomMoney = Random.Range(200,300);
        money += randomMoney;
        PlayerPrefs.SetInt("Money",money);
        currentmoneytext.text = randomMoney + "";
        moneytext.text = money + "";
    }
}
