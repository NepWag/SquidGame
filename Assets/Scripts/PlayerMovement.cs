using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    public Animator playeranim;
    public bool _IsMove;
    public GameObject playerskin;
    public static PlayerMovement instance;
    public GameObject TryAgainPanel;
    public GameObject CongratsPanel;
    public GameObject Money;
    public GameObject MoneyImage;
    public GameObject MoneyEffect;
    public GameObject Camera3;
    public GameObject Controls;
    public GameObject DisabledPanel;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        _IsMove = false;
    }

    void Update()
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

    public void OnPlayerDied()
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

     void MoneyAdd()
     {
              MoneyManager.instance.AddMoney();
     }

     IEnumerator GameOverCoroutine()
     {
          DisabledPanel.SetActive(true);
          yield return new WaitForSeconds(3f);
          LeanTween.scale(TryAgainPanel, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.pingPong).setDelay(3f);
     }

     public void GameOver()
     {
          StartCoroutine("GameOverCoroutine");
     }
}
