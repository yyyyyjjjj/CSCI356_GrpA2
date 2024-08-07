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
    public float MovePower;

    void Start()
    {
        initialize();
    }

    public void battleMove()
    {
        Character player = GetComponent<Character>();

        MovePower = player.movePower;

        Vector3 currentPosition = player.transform.position;

        float distanceThisFrame = Vector3.Distance(lastPosition, currentPosition);

        totalDistance += distanceThisFrame;
        percentage = 1 - (totalDistance / player.movePower);


        lastPosition = currentPosition;

        if (MovePower > totalDistance)
        {
            if (Input.GetMouseButton(0))   
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))   
                {
                    agent.SetDestination(hit.point);  
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
