using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <Summary>
/// Player Movement : Move of player through joystick
/// </Summary>
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Player Controller
    private Vector3 playerVelocity;   // Player Velocity
    private bool groundedPlayer;
    private float playerSpeed;   // Speed of player
    public Animator playeranim;   // Animator Controller
    public bool _IsMove;
    public GameObject playerskin;    // Skin Change into white after gameOver
    public static PlayerMovement instance;
    public GameObject TryAgainPanel;   // TryAgain panel 
    public GameObject CongratsPanel;   // Congratulation panel
    public GameObject Money;
    public GameObject MoneyImage;    // Money Image 
    public GameObject MoneyEffect;    // Money Effect after winner
    public GameObject Camera3;     // Winner Camera 
    public GameObject Controls;    // Controls of player
    public GameObject DisabledPanel;   // Disabled Panel
    public TMP_Text Ranktext;
    public bool GameStarted = true;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        _IsMove = false;
        Invoke("DisablePanel",3f);
        playerSpeed = PlayerPrefs.GetFloat("PlayerSpeed");
    }

    void Update()  // Update the player movement
    {
        if(GameStarted)
        {
        Vector3 move = new Vector3(Joystick.instance.Horizontal, 0, Joystick.instance.Vertical);
        controller.Move(move * Time.deltaTime * playerSpeed);
        move.Normalize();
        
        if (move != Vector3.zero)
        {
            if( TimeCount.instance.CanCount == false)
            {
                 TimeCount.instance.CanCount = true;
            }
            if(_IsMove == false)
            {
                 _IsMove = true;
            }
            gameObject.transform.forward = move;
        }
        else
        {
            if(_IsMove == true)
            {
                _IsMove = false;
            }
        }
        controller.Move(playerVelocity * Time.deltaTime);
        playeranim.SetFloat("Horizontal",Joystick.instance.Horizontal);
        playeranim.SetFloat("Vertical",Joystick.instance.Vertical);
        };
    }

    public void DisablePanel()
    {
        DisabledPanel.SetActive(false);
    }

    public void OnPlayerDied()   // Onplayer Die
    {
        TimeCount.instance.isTimer = false;
        GameStarted = false;
        DisabledPanel.SetActive(true);
        playeranim.SetBool("Died", true);
        playerskin.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.white);
        StartCoroutine("GameOverCoroutine");
    }
    
    void OnTriggerEnter( Collider theCollision )
    {    
        if (theCollision.gameObject.tag == "Finish")
        { 
            _IsMove = false;
            Controls.SetActive(false);
            MoneyEffect.SetActive(true);
            GameStarted = false;
            Camera3.SetActive(true);
            playeranim.SetBool("Dance", true);
            LeanTween.scale(CongratsPanel, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.pingPong).setDelay(4f);
            TimeCount.instance.isTimer = false;
            Invoke("MoneyAdd",2f);
            RankManager.instance.RankUp();
            Ranktext.text = RankManager.instance.rank + "";
            LevelAdd();
        }
    }
    public void LevelAdd()
    {
        int gameLevel = PlayerPrefs.GetInt("GameLevel");
        PlayerPrefs.SetInt("GameLevel",2);
    }

     void MoneyAdd()  // On Money Added
     {
         MoneyManager.instance.AddMoney();
     }

     IEnumerator GameOverCoroutine() // GameOver Count Down
     {
          yield return new WaitForSeconds(2f);
          LeanTween.scale(TryAgainPanel, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.pingPong).setDelay(3f);
     }

     public void GameOver()  //  OnGameOver
     {
          StartCoroutine("GameOverCoroutine");
     }
}
