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
        //当前位置
        Vector3 currentPosition = player.transform.position;
        //计算当前帧与上一帧的距离
        float distanceThisFrame = Vector3.Distance(lastPosition, currentPosition);

        //总共移动的距离
        totalDistance += distanceThisFrame;
        percentage = 1 - (totalDistance / player.movePower);

        // 更新上一帧的位置为当前帧的位置
        lastPosition = currentPosition;

        if (MovePower > totalDistance)
        {
            if (Input.GetMouseButton(0))   // 检查是否点击了鼠标左键
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))   // 发射射线检测碰撞
                {
                    agent.SetDestination(hit.point);   // 设置NavMesh代理的目标位置为射线碰撞点
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
