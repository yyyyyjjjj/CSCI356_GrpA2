using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AItest : MonoBehaviour
{
    SystemControl SC;
    public GameObject Sc;

    NavMeshAgent agent;

    public Transform[] target;  // 存放四个目标点的Transform数组
    private int currentTargetIndex = 0;  // 当前目标点的索引
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextTarget();
    }

    // Update is called once per frame
    void Update()
    {        
        // 如果到达当前目标点，移动到下一个目标点
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            MoveToNextTarget();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);

        testPlayer();
    }
    void MoveToNextTarget()
    {

        // 设置下一个目标点
        agent.SetDestination(target[currentTargetIndex].position);

        // 更新索引，循环到起始点
        currentTargetIndex = (currentTargetIndex + 1) % target.Length;
    }

    void testPlayer()
    {
        SC = Sc.GetComponent<SystemControl>();
        if (SC.state == BattleState.BATTLESTART)
        {
            agent.isStopped = true;
        }
    }
}
