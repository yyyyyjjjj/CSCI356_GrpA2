using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    MonsterData monsterData;

    private void Update()
    {
        GameObject monster = GameObject.FindWithTag("monster1");
        monsterData = monster.GetComponent<MonsterData>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        monsterData.takenDamage(3);
        Destroy(gameObject);
    }
}
