using OpenCover.Framework.Model;
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
    public Animator playerAnimator;
    public Transform playerPosition;
    public GameObject Sc;
    public GameObject monsterObject;
    public GameObject monsterEffect;

    public Transform monsterPosition1;
    public Transform playerPostion;

    public GameObject fireballPrefab;
    public Transform firePosition;
    public GameObject warningSign;
    public GameObject aoePrefab;

    // Audio related variables
    public AudioClip dragonGrowl;
    public AudioClip fireBreath;
    public AudioClip roar;
    private AudioSource audioSource;

    public float fireballSpeed = 20f;
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

            if (distance > 12)
            {
                if (SC.hasUsedDefense == true)
                {
                    StartCoroutine(ExecuteAfterDelay(0.5f, fireball));
                    // Play the fire breath sound
                    PlaySound(fireBreath);

                    // when distance > 12, monster fly and shot fireball(doesn't move)
                    agent.SetDestination(transform.position); // stop moving
                    animator.SetBool("isMoving", false);
                    animator.SetTrigger("isFire");

                    player.currentHP -= monster.AiDamage * 3 / 4;
                    SC.hasUsedDefense = false;
                    SC.defenseAnimation.SetActive(false);
                    // change turn
                    SC.state = BattleState.PLAYERTURN;

                }
                else
                {
                    StartCoroutine(ExecuteAfterDelay(0.5f, fireball));
                    // Play the fire breath sound
                    PlaySound(fireBreath);

                    agent.SetDestination(transform.position); // stop moving
                    animator.SetBool("isMoving", false);
                    animator.SetTrigger("isFire");
                    SC.hasUsedDefense = false;
                    player.currentHP -= monster.AiDamage * 3 / 2;
                    // change turn
                    SC.state = BattleState.PLAYERTURN;
                }

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
                    if (SC.roundTims % 4 == 1)
                    {
                        animator.SetTrigger("isAttack");
                        PlaySound(dragonGrowl);
                    }
                    else if (SC.roundTims % 4 == 2)
                    {
                        animator.SetTrigger("isTailAttack");
                        PlaySound(dragonGrowl);
                    }
                    else if (SC.roundTims % 4 == 3)
                    {
                        //animator.SetTrigger("isFire");
                        animator.SetBool("isFlying", true);
                        monsterEffect.SetActive(true);
                        monster.AiDamage *= 3;
                        warningSign.SetActive(true);
                        PlaySound(roar);
                    }
                    else
                    {
                        //StartCoroutine(ExecuteAfterDelay(2.0f, fireball));
                        StartCoroutine(ExecuteAfterDelay(1.2f, bossAttack));
                        animator.SetBool("isFlying", false);
                        animator.SetTrigger("fireBallShot");
                        monsterEffect.SetActive(false);
                        warningSign.SetActive(false);
                        PlaySound(fireBreath);
                    }


                    if (SC.roundTims % 4 != 3)
                    {
                        if (SC.hasUsedDefense == true)
                        {
                            player.currentHP -= monster.AiDamage / 2;
                        }
                        else
                        {
                            player.currentHP -= monster.AiDamage;
                        }
                        playerAnimator.SetTrigger("isHit");
                        monster.AiDamage = 5;  //reset monster damage;
                    }
                    SC.hasUsedDefense = false;
                    SC.defenseAnimation.SetActive(false);

                    // change turn
                    SC.state = BattleState.PLAYERTURN;
                }
            }
        }
    }


    void fireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePosition.position, firePosition.rotation);

        firePosition.transform.LookAt(playerPostion.position);

        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePosition.forward * fireballSpeed;
        }
    }

    void bossAttack()
    {
        aoePrefab.SetActive(true);
        StartCoroutine(ExecuteAfterDelay(5.0f, bossAttackEnd));
    }

    void bossAttackEnd()
    {
        aoePrefab.SetActive(false);
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
