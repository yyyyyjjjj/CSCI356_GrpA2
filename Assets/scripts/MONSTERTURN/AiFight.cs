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
    public int stoppingDistance = 0;

    public GameObject monsterObject;


    //current HP
    //public float HpPercentage;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = monsterObject.GetComponent<Animator>();
    }


    void Update()
    {
        // find player object
        GameObject playerObject = GameObject.FindWithTag("Player");
        // get reference
        PlayerData player = playerObject.GetComponent<PlayerData>();
        // get monster reference
        MonsterData monster = monsterObject.GetComponent<MonsterData>();
        // get system control reference 
        SC = Sc.GetComponent<SystemControl>();


        if (SC.state == BattleState.ENEMTURN)
        {
            //set destination
            agent.SetDestination(playerPosition.position);

            //get distance
            float distance = Vector3.Distance(playerPosition.position, transform.position);

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            //when distance lower than setting distance
            if (distance <= 6)
            {
                Debug.Log("roundTimes:" + SC.roundTimes);
                Debug.Log(SC.roundTimes % 3);

                // skill 1 here !!!
                if (SC.roundTimes % 3 == 1)
                {
                    // this is a player sill, if he else dou yao xie animator
                    if (SC.hasUsedDefense == true)
                    {
                        //AI stop at 2f distance to player
                        agent.SetDestination(transform.position);

                        //AI attack
                        player.currentHP -= monster.AiDamage / 2;

                        animator.SetTrigger("isAttack");

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

                // skill 2 here !!!
                if (SC.roundTimes % 3 == 2)
                {
                    // ni men zhao zhe shang mian de xie
                    // wo ye bu zhi dao ni men yao she ji shen me skill 2
                    // ji de ba guai wu de animator complete le
                }

                if (SC.roundTimes % 3 == 0)
                {
                    // for now we only have 3 ge skill
                    // if ni men you more skill jiu wang hou jia
                }
            }
        }


    }
}
