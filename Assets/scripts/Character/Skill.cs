using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    SystemControl SC;

    public Animator animator;
    public Transform playerPosition;
    public GameObject Sc;
    //setting distance
    public float stoppingDistance = 2f;
    public GameObject player;
    //current HP
    //public float HpPercentage;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SC = Sc.GetComponent<SystemControl>();
        animator = player.GetComponent<Animator>();


    }




    }

