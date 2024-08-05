using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AItest : MonoBehaviour
{
    SystemControl SC;
    public GameObject Sc;

    NavMeshAgent agent;

    public Transform[] target;  // ����ĸ�Ŀ����Transform����
    private int currentTargetIndex = 0;  // ��ǰĿ��������
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextTarget();
    }

    // Update is called once per frame
    void Update()
    {        
        // ������ﵱǰĿ��㣬�ƶ�����һ��Ŀ���
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            MoveToNextTarget();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);

        testPlayer();
    }
    void MoveToNextTarget()
    {

        // ������һ��Ŀ���
        agent.SetDestination(target[currentTargetIndex].position);

        // ����������ѭ������ʼ��
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
