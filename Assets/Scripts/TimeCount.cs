using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/// <Summary>
/// Time Clock Counting
/// </Summary>
public class TimeCount : MonoBehaviour
{
    public GameObject textTimer;
    [SerializeField]
    private float timer = 90f;
    public bool isTimer = false;
    public bool CanCount = false;
    public static TimeCount instance;
    public bool IsTimeBegin = false;

    public void Awake()
    {
         if(instance == null)
         {
              instance = this;
         }
    }

    void Update()
    {
        if(isTimer == true && CanCount == true)
        {
             if(IsTimeBegin == false)
             {
                  IsTimeBegin = true;
             }
                timer -= Time.deltaTime;
                DisplayTime();
        }

        if(timer < 1)
        {
                PlayerMovement.instance.GameOver();
                isTimer = false;
        }
    }

    void DisplayTime()  // Display the time counting
    {
           int minutes = Mathf.FloorToInt(timer / 60.0f);
           int seconds = Mathf.FloorToInt(timer - minutes * 60);
           textTimer.GetComponent<TextMesh>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StartTimer()   // Start the time
    {
           isTimer = true;
    }     
    public void StopTimer()   // Stop the time
    {
           isTimer = false;
    }   
}
