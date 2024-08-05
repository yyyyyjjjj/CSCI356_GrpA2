using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ClickToMove : MonoBehaviour
{
    public LayerMask groundLayer;   // �����ͼ�㣬ȷ��ֻ�е��汻���ʱ�Ż��ƶ�
    public NavMeshAgent agent;      // NavMesh���������ƶ�
    public Transform player; //�����ҵ�ǰλ��
    //��ȡ����ֵֹͣ��scripEnable���� EventSystem �����
    public GameObject SC;
    // �Ƿ�ֹͣ
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
}
