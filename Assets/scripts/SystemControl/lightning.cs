using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    MonsterData monsterData;

    private void Update()
    {
        GameObject monster = GameObject.FindWithTag("monster1");
        monsterData = monster.GetComponent<MonsterData>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        monsterData.takenDamage(2);
        Destroy(gameObject);
    }
}
