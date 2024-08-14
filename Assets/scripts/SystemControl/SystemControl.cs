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
    public GameObject HpUi;
    public GameObject moveUi;
    // button object
    public Button EndRdButton;
    public Image HP;
    public Image MovePower;
    //agent
    public NavMeshAgent PlayerAgent;
    //UI
    public UIcontroller canvasController;
    //Music
    //public musicControl music;
    //public GameObject Music;

    public LayerMask groundLayer;   // layer ground
    public NavMeshAgent agent;      // NavMesh agent

    // reference
    ClickToMoveBattle CTB;
    public BattleState state;

    // run one time
    private bool hasRun = false;

    private void Start()
    {
        state = BattleState.NORMAL;
        EndRdButton.onClick.AddListener(OnClick);
        //music = Music.GetComponent<musicControl>();
    }

    private void Update()
    {
        // Hp update in all state
        HpController();
        // using these reference
        CTB = player.GetComponent<ClickToMoveBattle>();

        MovePower = moveUi.GetComponent<Image>();
        HP = HpUi.GetComponent<Image>();

        
        // NORMAL state
        if (state == BattleState.NORMAL)
        {
            // player basic movement in the normal state
            normalMove();

            //initialize percentage
            CTB.percentage = 1;
            MovePower.fillAmount = 1;
            hasRun = false;
        }

        if (state == BattleState.BATTLESTART)
        {
            canvasController.ShowCanvasForSeconds(2f);

            state = BattleState.PLAYERTURN;

            //initialize percentage
            CTB.percentage = 1;
            MovePower.fillAmount = 1;
            hasRun = false;

        }
        
        //PLAYERTURN state
        if (state == BattleState.PLAYERTURN)
        {
            if (hasRun == false)
            {
                MovePower.fillAmount = 1;
                PlayerAgent.ResetPath();
                CTB.totalDistance = 0;
                hasRun = true;
            }

            BattleMovePowerController();
            // player turn basic movement in the battle state.
            CTB.battleMove();
        }

        //ENEMYTURN state
        if (state == BattleState.ENEMTURN)
        {

            //initialize percentage
            CTB.percentage = 1;
            hasRun = false;
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


    void HpController ()
    {
        //some object get;
        GameObject playerObject = GameObject.FindWithTag("Player");
        Character character = playerObject.GetComponent<Character>();


        //percentage of HP UI;
        float HpPercentage = character.currentHP / character.maxHP;
        HP.fillAmount = HpPercentage;
    }

    void BattleMovePowerController()
    {        
        float MovePercentage = CTB.percentage;
        MovePower.fillAmount = MovePercentage;
    }

    void normalMove()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
