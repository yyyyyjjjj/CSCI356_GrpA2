using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    public float raycastDistance = 100f; // ���ߵĳ���
    public bool isAttacking = false; // �Ƿ����ڹ������
    //���AItest�����
    AItest aitest;
    AIinBattle aIinBattle;

    public Transform player; // ��Ҷ��������

    private void Start()
    {
        aitest = GetComponent<AItest>();
        aIinBattle = GetComponent<AIinBattle>();
    }
    void Update()
    {
        // ʹ��Transform.LookAt������ʹ���峯�����λ��
        transform.LookAt(player.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // ������߻�������ң���ʼ�����߼�
                if (!isAttacking)
                {
                    StartAttack();
                    aitest.enabled = false;
                    aIinBattle.enabled = true;
                }
            }
        }
    }
    void StartAttack()
    {
        isAttacking = true;
    }

}
