using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFight : MonoBehaviour
{
    NavMeshAgent agent;
    SystemControl SC;
    private Animator animator;


    public Transform playerPosition;
    public GameObject Sc;
    //setting distance
    public float stoppingDistance = 5f;

    public GameObject monsterObject;


    //current HP
    //public float HpPercentage;

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
            //set destination
            agent.SetDestination(playerPosition.position);

            //get distance
            float distance = Vector3.Distance(playerPosition.position, transform.position);

            //when distance lower than setting distance
            if (distance <= 5)
            {
                if (SC.roundTims % 3 == 1)
                {
                    if (SC.hasUsedDefense == true)
                    {
                        //AI stop at 2f distance to player
                        agent.SetDestination(transform.position);

                        //AI attack
                        player.currentHP -= monster.AiDamage / 2;

                        animator.SetTrigger("isAttack");

                        SC.hasUsedDefense = false;
                        //change turn to player
                        SC.state = BattleState.PLAYERTURN;
                    }
                    else
                    {
                        //AI stop at 2f distance to player
                        agent.SetDestination(transform.position);

                        //AI attack
                        player.currentHP -= monster.AiDamage;
                        Debug.Log("currentHP: " + player.currentHP);
                        animator.SetTrigger("isAttack");

                        //change turn to player
                        SC.state = BattleState.PLAYERTURN;
                    }
                }else if (SC.roundTims % 3 == 2)
                {
                    if (SC.hasUsedDefense == true)
                    {
                        //AI stop at 2f distance to player
                        agent.SetDestination(transform.position);

                        //AI attack
                        player.currentHP -= monster.AiDamage / 2;
                        // second animation here
                        // just change the trigger
                        // if you want we can add new damage to this attack
                        // but now we first done this
                        animator.SetTrigger("isAttack");

                        SC.hasUsedDefense = false;
                        //change turn to player
                        SC.state = BattleState.PLAYERTURN;
                    }
                    else
                    {
                        //AI stop at 2f distance to player
                        agent.SetDestination(transform.position);

                        //AI attack
                        player.currentHP -= monster.AiDamage;
                        Debug.Log("currentHP: " + player.currentHP);
                        animator.SetTrigger("isAttack");

                        //change turn to player
                        SC.state = BattleState.PLAYERTURN;
                    }
                }
                else if (SC.roundTims % 3 == 0)
                {
                    if (SC.hasUsedDefense == true)
                    {
                        //AI stop at 2f distance to player
                        agent.SetDestination(transform.position);

                        //AI attack
                        player.currentHP -= monster.AiDamage / 2;
                        // here is third attack animation
                        // change the trigger
                        // I already test every
                        // for now everything just find.
                        animator.SetTrigger("isAttack");

                        SC.hasUsedDefense = false;
                        //change turn to player
                        SC.state = BattleState.PLAYERTURN;
                    }
                    else
                    {
                        //AI stop at 2f distance to player
                        agent.SetDestination(transform.position);

                        //AI attack
                        player.currentHP -= monster.AiDamage;
                        Debug.Log("currentHP: " + player.currentHP);
                        animator.SetTrigger("isAttack");

                        //change turn to player
                        SC.state = BattleState.PLAYERTURN;
                    }
                }
                
                
            }
        }


    }
}
