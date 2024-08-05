using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIinBattle : MonoBehaviour
{
    NavMeshAgent agent;
    SystemControl SC;
    //��ȡ���λ��
    public Transform playerPosition;
    public GameObject Sc;
    //������
    public float stoppingDistance = 2f;
    //����Character��ʹ�ý�ɫ����
    Character character;
    //���Ŀ���Ƿ��ѹ���
    private bool hasAttack = false;
    //���AI�Ƿ�ִ�����
    public GameObject AiOver;
    EndRoundBtn over;
    //���ĿǰѪ��
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
            //����AIĿ�ĵ�
            agent.SetDestination(playerPosition.position);
            //����AI����ҵľ���
            float distance = Vector3.Distance(playerPosition.position, transform.position);
            //������С�����þ���ʱ...
            if (distance <= stoppingDistance)
            {
                //AI�ھ������2f�ľ���ͣ��
                agent.SetDestination(transform.position);
                
                if (hasAttack == false)
                {
                    //AI��������,��ҿ�Ѫ
                    character.currentHP -= character.AiDamage;                    
                    //AI״̬��Ϊtrue��
                    hasAttack = true;
                    //�����غϽ׶�
                    over = AiOver.GetComponent<EndRoundBtn>();
                    over.playerPassTurn = false;
                }
                hasAttack = false;                
            }
        }
              
        
    }
}
