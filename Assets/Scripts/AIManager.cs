using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Vector3 moveDirection;
    public GameObject Target;
    void Start()
    {
        target = Target.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        moveDirection = new Vector3(Random.Range(-100f, 100f), 0, 100f);
        agent.SetDestination(moveDirection);
    }
}
