using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AiFight : MonoBehaviour
{
    NavMeshAgent agent;
    SystemControl SC;
    private Animator animator;
    public Transform playerPosition;
    public GameObject Sc;
    public GameObject monsterObject;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SC = Sc.GetComponent<SystemControl>();
        animator = monsterObject.GetComponent<Animator>();
    }

    void Update()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        PlayerData player = playerObject.GetComponent<PlayerData>();
        MonsterData monster = monsterObject.GetComponent<MonsterData>();

        if (SC.state == BattleState.ENEMTURN)
        {
            // get distance between monster and player
            float distance = Vector3.Distance(playerPosition.position, transform.position);

            if (distance > 12)
            {
                // when distance > 12, monster fly and shot fireball(doesn't move)
                agent.SetDestination(transform.position); // stop moving
                animator.SetBool("isMoving", false);
                animator.SetTrigger("fireBallShot");

                player.currentHP -= monster.AiDamage * 3/2;
                // change turn
                SC.state = BattleState.PLAYERTURN;
            }
            else
            {
                // whem distance <= 12, move to player and attack
                agent.SetDestination(playerPosition.position); 
                animator.SetBool("isMoving", true);

                if (distance <= 5) 
                {
                    //stop moving
                    animator.SetBool("isMoving", false);
                    agent.SetDestination(transform.position);

                    // choose attack way
                    if (SC.roundTims % 3 == 1)
                    {
                        animator.SetTrigger("isAttack");
                    }
                    else if (SC.roundTims % 3 == 2)
                    {
                        animator.SetTrigger("isTailAttack");
                    }
                    else 
                    {
                        animator.SetTrigger("isFire");
                    }
                    

                    if (SC.hasUsedDefense == true)
                    {
                        player.currentHP -= monster.AiDamage / 2;
                    }
                    else
                    {
                        player.currentHP -= monster.AiDamage;
                    }
                    // change turn
                    SC.state = BattleState.PLAYERTURN;
                }
            }
        }
    }
}
