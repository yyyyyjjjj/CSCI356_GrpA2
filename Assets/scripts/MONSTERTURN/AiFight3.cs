using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AiFight3 : MonoBehaviour
{
    NavMeshAgent agent;
    SystemControl SC;
    private Animator animator;
    public Animator playerAnimator;
    public Transform playerPosition;
    public GameObject Sc;
    public GameObject monsterObject;

    // Audio related variables
    public AudioClip attackSound1;
    public AudioClip attackSound2;
    private AudioSource audioSource;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SC = Sc.GetComponent<SystemControl>();
        animator = monsterObject.GetComponent<Animator>();

        // Initialize the AudioSource component
        audioSource = monsterObject.AddComponent<AudioSource>();
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

            // if player got lightning...cannot move 
            if (SC.stop == true)
            {
                Debug.Log("stop!");
                SC.stop = false;
                SC.state = BattleState.PLAYERTURN;
                return;
            }


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
                    animator.SetTrigger("isAttack1");
                    PlaySound(attackSound1);
                }
                else if (SC.roundTims % 3 == 2)
                {
                    animator.SetTrigger("isAttack2");
                    PlaySound(attackSound2);
                }


                if (SC.hasUsedDefense == true)
                {
                    player.currentHP -= monster.AiDamage / 2;
                    SC.defenseAnimation.SetActive(false);
                    SC.hasUsedDefense = false;
                }
                else
                {
                    player.currentHP -= monster.AiDamage;
                }
                playerAnimator.SetTrigger("isHit");
                monster.AiDamage = 5;  //reset monster damage;

                SC.hasUsedDefense = false;

                // change turn
                SC.state = BattleState.PLAYERTURN;
            }

        }
    }

    IEnumerator ExecuteAfterDelay(float delay, System.Action method)
    {
        yield return new WaitForSeconds(delay);

        method?.Invoke();
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
