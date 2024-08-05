using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.TextCore.Text;

//四种战斗状态
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
        //获得开始战斗的权限
        StartFight startFight = enemy.GetComponent<StartFight>();
        //检查怪物是否发现玩家，发现后将状态更新至BATTLESTART
        if (state == BattleState.NORMAL)
        {
            
        }
        if (startFight.isAttacking == true)
        {
            //入战
            TurnPass = playerBtn.GetComponent<EndRoundBtn>();
            //结束回合
            if (TurnPass.playerPassTurn == false)
            {
                state = BattleState.PLAYERTURN;
            }
            else
            {
                state = BattleState.ENEMTURN;
            }
        }

        //玩家回合状态
        if (state == BattleState.PLAYERTURN)
        {
            playerTurn();
        }
        //AI 回合状态
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
