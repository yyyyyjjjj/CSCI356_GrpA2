using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public UIcontroller popupController;
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

    //fireball
    public bool hasUsedFireBall = false;

    // round times
    public int roundTims = 0;

    //lightning
    public bool hasUsedLightning = false;

    //heal
    public bool hasHeal = false;
    private void Start()
    {
        state = BattleState.NORMAL;
        EndRdButton.onClick.AddListener(OnClick);
        animator = player.GetComponent<Animator>();
        animator.ResetTrigger("Attack");

    }

    private void Update()
    {
        AV = player.GetComponent<attackVoice>();
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
                ShowPlayerTurnPopup();
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
    attackVoice AV;
    void OnClick()
    {
        if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMTURN;
            hasUsedSkill = false; // Reset skill usage for the next turn
            hc.hasTakeDamage = false;
            hasUsedFireBall = false;
            hasUsedLightning = false;
            hasHeal = false;
            hc.times = false;
            roundTims += 1;
            AV.oneTimes = false;
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

    // Method to show popup at the start of player's turn
    void ShowPlayerTurnPopup()
    {
        popupController.ShowCanvasForSeconds(1f);
    }

    // Method to handle skill usage
    public void UseSkill()
    {
        // Ensure the skill can only be used during the player's turn


        float distance1 = Vector3.Distance(monsterPosition1.position, playerPostion.position);

        // if distance smaller than 2f
        if (distance1 <= 8f && hasUsedSkill == false && hasUsedDefense == false && hasUsedFireBall == false && hasUsedLightning == false & hasHeal == false)
        {
            animator.SetTrigger("NAttack");
            // Mark that the skill has been used
            hasUsedSkill = true;
        }else
        {
            animator.ResetTrigger("NAttack");
        }
    }

    public void defense()
    {
        if (hasUsedSkill == false && hasUsedDefense == false && hasUsedFireBall == false && hasUsedLightning == false & hasHeal == false)
        {
            hasUsedDefense = true;
            animator.SetTrigger("defense");
        }
    }

    public GameObject fireballPrefab;
    public Transform firePosition;
    public float fireballSpeed = 20f;
    public void fireball()
    {
        float distance = Vector3.Distance(monsterPosition1.position, playerPostion.position);
        

        if (distance <= 20f && hasUsedSkill == false && hasUsedDefense == false && hasUsedFireBall == false && hasUsedLightning == false & hasHeal == false)
        {
            GameObject fireball = Instantiate(fireballPrefab, firePosition.position, firePosition.rotation);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePosition.forward * fireballSpeed;
                animator.SetTrigger("Attack");
            }
            hasUsedFireBall = true;
        }
    }

    public GameObject lightPrefab;
    public float lightningSpeed = 20f;
    public void Lightning()
    {
        float distance = Vector3.Distance(monsterPosition1.position, playerPostion.position);


        if (distance <= 20f && hasUsedSkill == false && hasUsedDefense == false && hasUsedFireBall == false && hasUsedLightning == false & hasHeal == false)
        {
            GameObject lightning = Instantiate(lightPrefab, firePosition.position, firePosition.rotation);
            Rigidbody rb = lightning.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePosition.forward * lightningSpeed;
                animator.SetTrigger("Attack");
            }
            hasUsedLightning = true;
        }
    }

    
    public void healing()
    {
        if (hasUsedSkill == false && hasUsedDefense == false && hasUsedFireBall == false && hasUsedLightning == false && hasHeal == false)
        {
            hasHeal = true;            
        }
    }

}
