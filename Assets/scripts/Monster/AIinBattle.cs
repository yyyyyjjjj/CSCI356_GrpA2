using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIinBattle : MonoBehaviour
{
    NavMeshAgent agent;
    SystemControl SC;
    //获取玩家位置
    public Transform playerPosition;
    public GameObject Sc;
    //检测距离
    public float stoppingDistance = 2f;
    //传入Character，使用角色数据
    Character character;
    //检测目标是否已攻击
    private bool hasAttack = false;
    //检测AI是否执行完毕
    public GameObject AiOver;
    EndRoundBtn over;
    //玩家目前血量
    public float HpPercentage;

    void Start()
    {

    }


    void Update()
    {
        agent = GetComponent<NavMeshAgent>();
        SC = Sc.GetComponent<SystemControl>();
        character = GetComponent<Character>();
        if (SC.state == BattleState.ENEMTURN)
        {   
            //设置AI目的地
            agent.SetDestination(playerPosition.position);
            //计算AI与玩家的距离
            float distance = Vector3.Distance(playerPosition.position, transform.position);
            //当距离小于设置距离时...
            if (distance <= stoppingDistance)
            {
                //AI在距离玩家2f的距离停下
                agent.SetDestination(transform.position);
                
                if (hasAttack == false)
                {
                    //AI发动攻击,玩家扣血
                    character.currentHP -= character.AiDamage;                    
                    //AI状态调为true。
                    hasAttack = true;
                    //结束回合阶段
                    over = AiOver.GetComponent<EndRoundBtn>();
                    over.playerPassTurn = false;
                }
                hasAttack = false;                
            }
        }
              
        
    }
}
