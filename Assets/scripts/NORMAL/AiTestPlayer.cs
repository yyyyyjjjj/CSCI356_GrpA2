using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiTestPlayer : MonoBehaviour
{
    public float RaycastDistance = 100f; // ray line 

    public NavMeshAgent AiAgent;

    public Transform PlayerPosition; // player position

    SystemControl SC;
    public GameObject sc;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        SC = sc.GetComponent<SystemControl>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //AI look at player always
        transform.LookAt(PlayerPosition.position);
        // if state = normal
        if (SC.state == BattleState.NORMAL)
        {
            AItest();
        }
        if (SC.state == BattleState.BATTLESTART)
        {
            AiAgent.SetDestination(transform.position);
        }
    }
    void AItest()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, RaycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                SC.state = BattleState.BATTLESTART;
            }
        }
    }
}
