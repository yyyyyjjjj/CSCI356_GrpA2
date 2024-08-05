using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    public float raycastDistance = 100f; // 射线的长度
    public bool isAttacking = false; // 是否正在攻击玩家
    //获得AItest的物件
    AItest aitest;
    AIinBattle aIinBattle;

    public Transform player; // 玩家对象的引用

    private void Start()
    {
        aitest = GetComponent<AItest>();
        aIinBattle = GetComponent<AIinBattle>();
    }
    void Update()
    {
        // 使用Transform.LookAt方法来使物体朝向玩家位置
        transform.LookAt(player.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // 如果射线击中了玩家，开始攻击逻辑
                if (!isAttacking)
                {
                    StartAttack();
                    aitest.enabled = false;
                    aIinBattle.enabled = true;
                }
            }
        }
    }
    void StartAttack()
    {
        isAttacking = true;
    }

}
