using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Summary>
/// Ui Manager System
/// </Summary>
public class UiManager : MonoBehaviour
{
    public GameObject Settings;  // Setting Panel
    private bool IsSettingOn = false;
    public void SettingButton()
    {
        if(IsSettingOn == false)
        {
             SettingPop();
        }
        else
        {
             SettingPush();
        }
    }

    void SettingPop()  // Pop Up Setting Panel
    {
         IsSettingOn = true;
         LeanTween.move(Settings.GetComponent<RectTransform>(), new Vector3(87.70001f,-249.6f,0f),1f).setEaseInOutCubic().setDelay(0f);
    }

    void SettingPush()   // Push Up Setting Panel
    {
         IsSettingOn = false;
         LeanTween.move(Settings.GetComponent<RectTransform>(), new Vector3(-106f,-249.6f,0f),1f).setEaseInOutCubic().setDelay(0f);
    }

}
