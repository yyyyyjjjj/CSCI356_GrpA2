using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{
    //AI HP
    public int AiHP;
    //ai damage
    public int AiDamage;
    //max Hp
    public float AiMaxHp;
    //current Hp
    public float AiCurrentHp;
    public Animator animator;
    public SystemControl systemControl;
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (AiCurrentHp <= 0)
        {
            AiCurrentHp = 0;
            Die(); 
        }
    }

    void Die()
    {
        animator.SetTrigger("Death"); // death animation
        GetComponent<Collider>().enabled = false; 
        this.enabled = false; 

        if (systemControl != null)
        {
            systemControl.state = BattleState.NORMAL;
        }

    }
}
