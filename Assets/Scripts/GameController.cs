using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool IsAudioOn;
    [SerializeField]
    private GameObject Camera1,Camera2;
    public GameObject SwipeOption;
    public GameObject JoyStick;
    public static GameController instance;
    public GameObject TryAgain;
    void Awake()
    {

         if(instance == null)
         {
              instance = this;
         }
         IsAudioOn = false;
         Invoke("CameraSwitch",0.5f);
    }
    public void GoToHome()
    {
         SceneManager.LoadScene ("Main");
    }
    public void TriggerSound()
    {
         AudioListener.pause = !IsAudioOn;
         IsAudioOn = !IsAudioOn;
    }
    public void CameraSwitch()
    {
         Camera1.SetActive(true);
         Camera2.SetActive(false);   
    }

    public void StartGame()
    {
         SwipeOption.SetActive(false);
         JoyStick.SetActive(true);
    }

    public void TryAgainFunc()
    {
        TryAgain.SetActive(true);
    }

    public void RestartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
