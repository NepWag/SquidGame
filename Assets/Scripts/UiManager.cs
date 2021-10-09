using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Settings;
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

    void SettingPop()
    {
             IsSettingOn = true;
             LeanTween.move(Settings.GetComponent<RectTransform>(), new Vector3(87.70001f,-249.6f,0f),1f).setEaseInOutCubic().setDelay(0f);
    }

    void SettingPush()
    {
             IsSettingOn = false;
             LeanTween.move(Settings.GetComponent<RectTransform>(), new Vector3(-106f,-249.6f,0f),1f).setEaseInOutCubic().setDelay(0f);
    }

}
