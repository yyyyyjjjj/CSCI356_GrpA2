using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMoveBattle : MonoBehaviour
{
    public LayerMask groundLayer;   // �����ͼ�㣬ȷ��ֻ�е��汻���ʱ�Ż��ƶ�
    public NavMeshAgent agent;      // NavMesh���������ƶ�
    private Vector3 lastPosition; //��һ֡λ��
    public float totalDistance; //һ���ƶ��ľ���
    public float percentage; //�ƶ��ٷֱ�

    
    
    void Start()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        battleMove();        
    }


    void battleMove()
    {
        Character player = GetComponent<Character>();

        float MovePower = player.movePower;
        //��ǰλ��
        Vector3 currentPosition = player.transform.position;
        //���㵱ǰ֡����һ֡�ľ���
        float distanceThisFrame = Vector3.Distance(lastPosition, currentPosition);

        //�ܹ��ƶ��ľ���
        totalDistance += distanceThisFrame;
        percentage = 1 - (totalDistance / player.movePower);

        // ������һ֡��λ��Ϊ��ǰ֡��λ��
        lastPosition = currentPosition;

        if (MovePower > totalDistance)
        {
            if (Input.GetMouseButton(0))   // ����Ƿ�����������
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))   // �������߼����ײ
                {
                    agent.SetDestination(hit.point);   // ����NavMesh�����Ŀ��λ��Ϊ������ײ��
                }
            }
        }
        else
        {
            agent.SetDestination(currentPosition);
        }

    }

    void initialize()
    {
        lastPosition = transform.position;
        totalDistance = 0f;
    }
}
