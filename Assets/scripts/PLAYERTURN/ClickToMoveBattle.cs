using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMoveBattle : MonoBehaviour
{
    public LayerMask groundLayer;   // 地面的图层，确保只有地面被点击时才会移动
    public NavMeshAgent agent;      // NavMesh代理，用于移动
    private Vector3 lastPosition; //上一帧位置
    public float totalDistance; //一共移动的距离
    public float percentage; //移动百分比
    public float MovePower;
    public GameObject SC;
    SystemControl sc;

    //run one time
    private bool hasRun = false;
    void Start()
    {
        lastPosition = transform.position;
        totalDistance = 0;
        sc = SC.GetComponent<SystemControl>();
    }

    public void battleMove()
    {
        if (sc.state == BattleState.PLAYERTURN)
        {            
            
            //reference
            Character player = GetComponent<Character>();
            MovePower = player.movePower;

            Vector3 currentPosition = player.transform.position;
            

            

            if (hasRun == false)
            {
                //initialize percentage and totalDistance
                percentage = 1;
                totalDistance = 0;
                hasRun = true;
            }else
            {
                float distanceThisFrame = Vector3.Distance(lastPosition, currentPosition);

                totalDistance += distanceThisFrame;

                percentage = 1 - (totalDistance / player.movePower);
            }

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
    }
}
