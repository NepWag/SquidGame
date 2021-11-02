using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxUpDown : MonoBehaviour
{
    private bool UpDown = true;
    void Update()
    {
        if (UpDown)
             transform.Translate(0, Time.deltaTime * 0.3f, 0, Space.World);
        else
             transform.Translate(0, -Time.deltaTime * 0.3f, 0, Space.World);
        if(transform.position.y >= -2.33f) 
        {
             UpDown = false;
        }         
        if(transform.position.y <= -4.5) 
        {
             UpDown = true;
        }  
    }
}
