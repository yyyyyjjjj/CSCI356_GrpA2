using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFight : MonoBehaviour
{
    NavMeshAgent agent;
    SystemControl SC;

    public Transform playerPosition;
    public GameObject Sc;
    //setting distance
    public float stoppingDistance = 2f;

    public GameObject monsterObject;

    
    //current HP
    //public float HpPercentage;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SC = Sc.GetComponent<SystemControl>();

        
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
            if (distance <= stoppingDistance)
            {
                //AI stop at 2f distance to player
                agent.SetDestination(transform.position);

                //AI attack
                player.currentHP -= monster.AiDamage;
                Debug.Log("currentHP: " + player.currentHP);

                //change turn to player
                SC.state = BattleState.PLAYERTURN;
            }
        }


    }
}
