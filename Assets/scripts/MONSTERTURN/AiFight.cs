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
        Character character = playerObject.GetComponent<Character>();

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
                character.currentHP -= character.AiDamage;                                     

                //change turn to player
                SC.state = BattleState.PLAYERTURN;

                Debug.Log("current HP: " + character.currentHP);
            }
        }


    }
}
