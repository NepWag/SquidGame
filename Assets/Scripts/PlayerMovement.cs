using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Summary>
/// Player Movement : Move of player through joystick
/// </Summary>
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Player Controller
    private Vector3 playerVelocity;   // Player Velocity
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;   // Speed of player
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
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        _IsMove = false;
    }

    void Update()  // Update the player movement
    {
        Vector3 move = new Vector3(Joystick.instance.Horizontal, 0, Joystick.instance.Vertical);
        controller.Move(move * Time.deltaTime * playerSpeed);
        move.Normalize();
        if (move != Vector3.zero)
        {
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
    }

    public void OnPlayerDied()   // Onplayer Die
    {
        playeranim.SetBool("Died", true);
        playerskin.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.white);
        StartCoroutine("GameOverCoroutine");
    }
    
    void OnTriggerEnter( Collider theCollision )
    {    
        if (theCollision.gameObject.tag == "Finish")
        { 
            Controls.SetActive(false);
            MoneyEffect.SetActive(true);
            Camera3.SetActive(true);
            playeranim.SetBool("Dance", true);
            LeanTween.scale(CongratsPanel, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.pingPong).setDelay(4f);
            Invoke("MoneyAdd",2f);
        }
    }

     void MoneyAdd()  // On Money Added
     {
              MoneyManager.instance.AddMoney();
     }

     IEnumerator GameOverCoroutine() // GameOver Count Down
     {
          DisabledPanel.SetActive(true);
          yield return new WaitForSeconds(3f);
          LeanTween.scale(TryAgainPanel, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.pingPong).setDelay(3f);
     }

     public void GameOver()  //  OnGameOver
     {
          StartCoroutine("GameOverCoroutine");
     }
}
