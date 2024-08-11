using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEnable : MonoBehaviour
{
    public GameObject player;
    public GameObject SystemControl;

    SystemControl systemControl;

    ClickToMove noBatMove;

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
