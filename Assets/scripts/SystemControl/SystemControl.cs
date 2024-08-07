using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

//ËÄÖÖÕ½¶·×´Ì¬
public enum BattleState { NORMAL, BATTLESTART, PLAYERTURN, ENEMTURN, WON, LOST }
public class SystemControl : MonoBehaviour
{
    // some game object        
    public GameObject enemy;
    public GameObject player;
    // button object
    public Button EndRdButton;



    // reference
    ClickToMoveBattle CTB;
    ClickToMove CTM;
    public BattleState state;


    private void Start()
    {
        state = BattleState.NORMAL;
        EndRdButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {

        
        // using these reference
        CTM = player.GetComponent<ClickToMove>();
        CTB = player.GetComponent<ClickToMoveBattle>();

        // NORMAL state
        if (state == BattleState.NORMAL)
        {
            // player basic movement in the normal state
            CTM.normalMove();

        }

        if (state == BattleState.BATTLESTART)
        {
            state = BattleState.PLAYERTURN;
        }
        
        //PLAYERTURN state
        if (state == BattleState.PLAYERTURN)
        {
            
            // player turn basic movement in the battle state.
            CTB.battleMove();
            
        }

        //ENEMYTURN state
        if (state == BattleState.ENEMTURN)
        {
           
        }

        //debug
        Debug.Log("current state£º" + state);
    }
    
    
    //change state method
    void OnClick()
    {
        if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMTURN;
        }else if (state == BattleState.ENEMTURN)
        {
            state = BattleState.PLAYERTURN;
        }
        CTB.totalDistance = 0;
    }

    
    
}
