using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.TextCore.Text;

//����ս��״̬
public enum BattleState { NORMAL, BATTLESTART, PLAYERTURN, ENEMTURN, WON, LOST }
public class SystemControl : MonoBehaviour
{
    public BattleState state;
    public GameObject playerBtn;
    private EndRoundBtn TurnPass;
    public GameObject enemy;

    private void Start()
    {
        state = BattleState.NORMAL;       
    }

    private void Update()
    {
        //��ÿ�ʼս����Ȩ��
        StartFight startFight = enemy.GetComponent<StartFight>();
        //�������Ƿ�����ң����ֺ�״̬������BATTLESTART
        if (state == BattleState.NORMAL)
        {
            
        }
        if (startFight.isAttacking == true)
        {
            //��ս
            TurnPass = playerBtn.GetComponent<EndRoundBtn>();
            //�����غ�
            if (TurnPass.playerPassTurn == false)
            {
                state = BattleState.PLAYERTURN;
            }
            else
            {
                state = BattleState.ENEMTURN;
            }
        }

        //��һغ�״̬
        if (state == BattleState.PLAYERTURN)
        {
            playerTurn();
        }
        //AI �غ�״̬
        if (state == BattleState.ENEMTURN)
        {
            enemyTurn();
        }

    }

    void playerTurn()
    {

    }

    void enemyTurn()
    {

        state = BattleState.ENEMTURN;        
    }

}
