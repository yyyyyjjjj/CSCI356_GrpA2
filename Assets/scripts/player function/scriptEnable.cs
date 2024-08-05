using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEnable : MonoBehaviour
{
    // 获得物件
    public GameObject player;
    public GameObject SystemControl;

    //立即停止移动
    

    // 获得SystemControl的访问权限
    SystemControl systemControl;

    //获得脱战状态的移动脚本
    ClickToMove noBatMove;

    //获得战斗状态的移动脚本
    ClickToMoveBattle batMove;

    private void Start()
    {
        systemControl = SystemControl.GetComponent<SystemControl>();
        noBatMove = player.GetComponent<ClickToMove>();
        batMove = player.GetComponent<ClickToMoveBattle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (systemControl.state == BattleState.BATTLESTART || systemControl.state == BattleState.PLAYERTURN || systemControl.state == BattleState.ENEMTURN)
        {
            Invoke("stateChange",1f);
        }
        else if(systemControl.state == BattleState.NORMAL || systemControl.state == BattleState.WON || systemControl.state == BattleState.LOST)
        {
            noBatMove.enabled = true;
            batMove.enabled = false;

        }


    }
    void stateChange()
    {
        batMove.enabled = true;
        noBatMove.enabled = false;
    }
}
