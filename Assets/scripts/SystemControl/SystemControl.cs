using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum BattleState { NORMAL, BATTLESTART, PLAYERTURN, ENEMTURN, WON, LOST }

public class SystemControl : MonoBehaviour
{
    // Game objects and UI elements        
    public GameObject enemy;
    public GameObject player;

    public GameObject moveUi;

    // monster Ui
    public GameObject monsterUi;

    // Button and Image objects
    public Button EndRdButton;
    public Button SkillButton;    // Reference for the skill button

    public Image MovePower;

    // Agent and Animator
    public NavMeshAgent PlayerAgent;
    public Animator animator;

    // Other references
    public UIcontroller canvasController;
    public LayerMask groundLayer;
    public LayerMask UILayer;
    public NavMeshAgent agent;
    ClickToMoveBattle CTB;
    public BattleState state;

    // State management
    private bool hasRun = false;
    public bool isRunning;
    public bool isIdle;
    public bool hasUsedSkill = false;

    //HpController
    public GameObject HC;
    public HPController hc;

    //monster position
    public Transform monsterPosition1;
    public Transform playerPostion;

    //defense
    public bool hasUsedDefense = false;
    private void Start()
    {
        state = BattleState.NORMAL;
        EndRdButton.onClick.AddListener(OnClick);
        animator = player.GetComponent<Animator>();
        animator.ResetTrigger("Attack");

    }

    private void Update()
    {
        hc = HC.GetComponent<HPController>();
        // Update references
        CTB = player.GetComponent<ClickToMoveBattle>();
        MovePower = moveUi.GetComponent<Image>();


        // Check if the player is moving
        bool isPlayerMoving = PlayerAgent.velocity.magnitude > 0.1f;

        // Handle different states
        if (state == BattleState.NORMAL)
        {
            normalMove();
            CTB.percentage = 1;
            MovePower.fillAmount = 1;
            hasRun = false;

        }

        if (state == BattleState.BATTLESTART)
        {
            canvasController.ShowCanvasForSeconds(2f);
            state = BattleState.PLAYERTURN;  // Transition to player's turn after battle starts

            CTB.percentage = 1;
            MovePower.fillAmount = 1;
            hasRun = false;
            monsterUi.SetActive(true);
        }

        if (state == BattleState.PLAYERTURN)
        {
            if (!hasRun)
            {
                MovePower.fillAmount = 1;
                PlayerAgent.ResetPath();
                CTB.totalDistance = 0;
                hasRun = true;
            }

            BattleMovePowerController();
            CTB.battleMove();
        }

        if (state == BattleState.ENEMTURN)
        {
            CTB.percentage = 1;
            hasRun = false;


        }

        // Update animation states
        isRunning = isPlayerMoving;
        isIdle = !isPlayerMoving;
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("isIdle", isIdle);

        // Debug current state
        Debug.Log("Current state: " + state + ", isPlayerMoving: " + isPlayerMoving);
    }

    // Method to change state when the end round button is clicked
    void OnClick()
    {
        if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMTURN;
            hasUsedSkill = false; // Reset skill usage for the next turn
            hc.hasTakeDamage = false;
        }
        else if (state == BattleState.ENEMTURN)
        {
            state = BattleState.PLAYERTURN;
            hasUsedSkill = false; // Reset skill usage for the player's turn
        }
        CTB.totalDistance = 0;
    }


    // Method to control move power in battle
    void BattleMovePowerController()
    {
        float MovePercentage = CTB.percentage;
        MovePower.fillAmount = MovePercentage;
    }

    // Method to handle normal movement
    void normalMove()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {

                agent.SetDestination(hit.point);
                hasRun = true;
            }
        }
        else
        {
            hasRun = false;
        }

        isRunning = hasRun;
        isIdle = !hasRun;
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("isIdle", isIdle);
    }

    // Method to handle skill usage
    public void UseSkill()
    {
        // Ensure the skill can only be used during the player's turn


        float distance1 = Vector3.Distance(monsterPosition1.position, playerPostion.position);

        // if distance smaller than 2f
        if (distance1 <= 2f && hasUsedSkill == false)
        {
            animator.SetTrigger("Attack");
            // Mark that the skill has been used
            hasUsedSkill = true;
        }else
        {
            animator.ResetTrigger("Attack");
        }
    }

    public void defense()
    {
        if (hasUsedSkill == false)
        {
            hasUsedDefense = true;
        }
    }

}
