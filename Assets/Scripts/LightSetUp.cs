using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetUp : MonoBehaviour
{
    public static LightSetUp instance;
    public GameObject CheckLight;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public List<GameObject> lights;

    public void LightRedChange()
    {
        foreach (var light in lights)
        {
            light.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }

    public void LightGreenChange()
    {
        foreach (var light in lights)
        {
            light.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
}
