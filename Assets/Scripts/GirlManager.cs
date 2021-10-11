using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Summary>
/// Robot Girl System : Red and Green Light Check
/// </Summary>
public class GirlManager : MonoBehaviour
{
    public GameObject girl;  // Robot Girl
    private int randomNumber;  // Random Number Generator
    private int negativepositive;   // Negative and positive 
    public bool IsRotateClockWise;  // Rotate the robot 
    public GameObject CheckLight;    // Red and Green Light Trigger
    private bool IsCheckActive;   // IsCheckActive Trigger
    public AudioSource girlCount;   // Counting Audio
    public AudioSource GunSound;   // Gun Audio
    public static GirlManager instance;
    public bool _IsGirlActiveForAI = false;
    public void Awake()
    {
         if(instance == null)
         {
                instance = this; 
         }
    }
    void Start()
    {
           IsRotateClockWise = true;
           IsCheckActive = false;
           Time.timeScale = 1.25f;
    }
    public void StartGame()   // On START GAME 
    {
           girlCount.Play(); 
           Invoke("StartCheckPlayer",5f);
    }
    void Update()
    {
         if(IsCheckActive == true && PlayerMovement.instance._IsMove == true)
         {
                PlayerMovement.instance.OnPlayerDied(); 
                IsCheckActive = false;          
         }
    }

    void StartCheckPlayer()  // Starting check player
    {
           Invoke("CheckActive",0.5f);
           InvokeRepeating("RotateHead",0.05f,0.05f);
    }

    void CheckActive()  // Trigger IsCheckActive
    {
         IsCheckActive = true;
    }
    void RotateHead()  // Rotating head of robot
    {
        if(girl.transform.localRotation.eulerAngles.y > 180)
        {       
               if( _IsGirlActiveForAI == false)
               {
                     _IsGirlActiveForAI = true;
               }
                LightSetUp.instance.LightRedChange();
                girl.transform.Rotate(0f, -10f, 0f, Space.Self);
        }   
        else
        {  
                randomNumber = Random.Range(7,9);
                GunSound.Play();
                CheckLight.SetActive(true);
                CancelInvoke("RotateHead");
                InvokeRepeating("CheckPlayer",0.1f,0.1f);
                Invoke("TurnBack",randomNumber);
        }
    }
    void CheckPlayer()   // Turnback back and check player 
    {
        if(girl.transform.localRotation.eulerAngles.y <= 170)
        {
                IsRotateClockWise = false;
        }
        else if (girl.transform.localRotation.eulerAngles.y >= 190)
        {
                IsRotateClockWise = true;
        };

        if(IsRotateClockWise)
        {
                RotateCheck();   
        }
        else
        {
                AntiRotateCheck();
        }
    }

    void RotateCheck()   // Rotate clockwise
    {   
           girl.transform.Rotate(0f, -40 * Time.deltaTime, 0f, Space.Self);
    }

    void AntiRotateCheck()   // Rotate anti clockwise
    {
           girl.transform.Rotate(0f, 40 * Time.deltaTime , 0f, Space.Self);
    }

    void TurnBack()  // Turn Back On Checking Player
    {
           _IsGirlActiveForAI = false;
           girlCount.Play();
           IsCheckActive = false;
           LightSetUp.instance.LightGreenChange();
           CheckLight.SetActive(false);
           CancelInvoke("CheckPlayer");
           InvokeRepeating("GoToCounting",0.1f,0.1f);
    }

    void GoToCounting()   // Hide and Counting 1 2 3
    {
        if(girl.transform.localRotation.eulerAngles.y <= 350)
        {
                girl.transform.Rotate(0f, 10f, 0f, Space.Self);
        }
        else
        {
                CancelInvoke("GoToCounting");
                Invoke("StartCheckPlayer",3f);
        }
    }
}
