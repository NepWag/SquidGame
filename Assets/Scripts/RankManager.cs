using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int rank = 0;
    public static RankManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void RankUp()
    {
        rank++;       
    }
}
