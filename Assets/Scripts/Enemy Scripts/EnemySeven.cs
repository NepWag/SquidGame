using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeven: MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Vector3 moveDirection;
    public GameObject Target;
    public bool _IsDance = false;
    public bool _IsIdlle = true;
    public bool _IsDead = false;
    public bool _IsRun = false;
    public Animator enemyanim; 
    public GameObject enemyskin;
    public static EnemySeven instance; 
    public bool OneTimeCheck = false;
    public bool IsWinTheGame = false;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        target = Target.transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if( TimeCount.instance.IsTimeBegin == true)
        {
            if(GirlManager.instance._IsGirlActiveForAI == true && IsWinTheGame == false)
            {
                 if(OneTimeCheck == false)
                 {
                         OneTimeCheck = true;
                         int randomNo = Random.Range(0,9);
                         if(randomNo != 2)
                         {
                                 AiIdle();
                         }
                         else
                         {
                              enemyanim.SetBool("AiDied", true);
                              gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                              enemyskin.GetComponent<SkinnedMeshRenderer>().material.SetColor("_Color", Color.white);
                              Invoke("DestroyEnemy",3f);
                         }
                 }
            } 
            else 
            {
                 AiRun();
                 if(OneTimeCheck == true)
                 {
                     OneTimeCheck = false;
                 }
            }
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void AiRun()
    {
             enemyanim.SetBool("AiRun", true);
             enemyanim.SetBool("AiIdle", false);
             gameObject.GetComponent<NavMeshAgent>().isStopped = false;
             moveDirection = new Vector3(7f, 0, 17f);
             agent.SetDestination(moveDirection);
    }

    void AiIdle()
    {
             enemyanim.SetBool("AiIdle", true);
             enemyanim.SetBool("AiRun", false);
             gameObject.GetComponent<NavMeshAgent>().isStopped = true;
    }

    void RandomGenerateRun()
    {
        int randomNo = Random.Range(0,4);
        if(randomNo == 0)
        {
              enemyanim.SetBool("AiIdle", true);
        }
    }

    void OnTriggerEnter( Collider theCollision )
    {    
        if (theCollision.gameObject.tag == "Finish")
        { 
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            enemyanim.SetBool("AiDance", true);
            IsWinTheGame = true;
            RankManager.instance.RankUp();
        }
    }
}
