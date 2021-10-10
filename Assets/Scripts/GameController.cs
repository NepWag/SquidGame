using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <Summary>
/// Game Manager :  Manages all the scripts
/// </Summary>
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
    public void GoToHome()  // Home Scene
    {
         SceneManager.LoadScene ("Main");
    }
    public void TriggerSound()   // Sound Trigger
    {
         AudioListener.pause = !IsAudioOn;
         IsAudioOn = !IsAudioOn;
    }
    public void CameraSwitch()  // Blend the cameras
    {
         Camera1.SetActive(true);
         Camera2.SetActive(false);   
    }

    public void StartGame()   // Start the game
    {
         SwipeOption.SetActive(false);
         JoyStick.SetActive(true);
    }

    public void TryAgainFunc()   // TryAgain Panel On
    {
        TryAgain.SetActive(true);
    }

    public void RestartGame()   // Restart the game
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
