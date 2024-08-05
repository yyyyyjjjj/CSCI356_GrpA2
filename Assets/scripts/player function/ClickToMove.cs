using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ClickToMove : MonoBehaviour
{
    public LayerMask groundLayer;   // 地面的图层，确保只有地面被点击时才会移动
    public NavMeshAgent agent;      // NavMesh代理，用于移动
    public Transform player; //获得玩家当前位置
    //获取立即停止值（scripEnable）和 EventSystem 的组件
    public GameObject SC;
    // 是否停止
    public bool stop = false;

    void Update()
    {      
        normalMove();
        SystemControl Stop = SC.GetComponent<SystemControl>();
        if (Stop.state == BattleState.BATTLESTART)
        {
            agent.SetDestination(player.position);
            stop = true;
        }
    }
    void normalMove()
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
}
