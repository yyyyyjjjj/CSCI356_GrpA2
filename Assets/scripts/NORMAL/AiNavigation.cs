using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiNavigation : MonoBehaviour
{
    SystemControl SC;
    public GameObject Sc;

    NavMeshAgent agent;

    public Transform[] target; 
    private int currentTargetIndex = 0;  
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextTarget();
        SC = Sc.GetComponent<SystemControl>();
    }

    void Update()
    {        
        if (SC.state == BattleState.NORMAL)
        {
            enabled = true;
            movement();
        }
        if (SC.state != BattleState.NORMAL)
        {
            enabled = false;
        }
        
    }
    public void movement()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            MoveToNextTarget();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void MoveToNextTarget()
    {

    }   
}
