using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ClickToMoveBattle : MonoBehaviour
{
    public LayerMask groundLayer;   
    public NavMeshAgent agent;     
    private Vector3 lastPosition; 
    public float totalDistance; 
    public float percentage; 
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
            PlayerData player = GetComponent<PlayerData>();
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

                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }
                    else if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
                    {

                        agent.SetDestination(hit.point);
                        hasRun = true;
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
