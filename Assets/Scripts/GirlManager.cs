using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlManager : MonoBehaviour
{
    public GameObject girl;
    private int randomNumber;
    private int negativepositive;
    public bool IsRotateClockWise;
    public GameObject CheckLight;
    private bool IsCheckActive;
    public AudioSource girlCount;
    public AudioSource GunSound;
    public static GirlManager instance;
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

    public void StartGame()
    {
         girlCount.Play(); 
         Invoke("StartCheckPlayer",5f);
    }
    void FixedUpdate()
    {
         if(IsCheckActive == true && PlayerMovement.instance._IsMove == true)
         {
                PlayerMovement.instance.OnPlayerDied(); 
                IsCheckActive = false;
                Debug.Log("dead");              
         }
    }

    void StartCheckPlayer()
    {
        Invoke("CheckActive",0.5f);
        InvokeRepeating("RotateHead",0.05f,0.05f);
    }

    void CheckActive()
    {
         IsCheckActive = true;
    }
    void RotateHead()
    {
        if(girl.transform.localRotation.eulerAngles.y > 180)
        {
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

    void CheckPlayer()
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

    void RotateCheck()
    {   
         girl.transform.Rotate(0f, -40 * Time.deltaTime, 0f, Space.Self);
    }

    void AntiRotateCheck()
    {
         girl.transform.Rotate(0f, 40 * Time.deltaTime , 0f, Space.Self);
    }

    void TurnBack()
    {
         girlCount.Play();
         IsCheckActive = false;
         LightSetUp.instance.LightGreenChange();
         CheckLight.SetActive(false);
         CancelInvoke("CheckPlayer");
         InvokeRepeating("GoToCounting",0.1f,0.1f);
    }

    void GoToCounting()
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
