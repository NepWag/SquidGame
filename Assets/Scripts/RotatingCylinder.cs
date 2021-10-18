using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Summary>
/// Rotate Platform
/// </Summary>
public class RotatingCylinder : MonoBehaviour
{
    public GameObject cube;
    public int Randomnumber;
    void Start()
    {
         InvokeRepeating("GenerateRandom",3f,3f);
    }
    void FixedUpdate()
    {
         RotateCylinder();
    }

    public void RotateCylinder()
    {
        if(Randomnumber == 0)
        {
             cube.transform.Rotate(0f ,-0.5f, 0.0f, Space.Self);
        }
        else
        {
             cube.transform.Rotate(0f , 0.5f, 0.0f, Space.Self);
        }
    }

    public void GenerateRandom()
    {
         Randomnumber = Random.Range(0,2);
    }
}
