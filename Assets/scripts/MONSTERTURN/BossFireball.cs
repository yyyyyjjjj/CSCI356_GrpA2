using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour
{
    PlayerData playerData;

    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerData = player.GetComponent<PlayerData>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerData.takenDamage(3);
        Destroy(gameObject);
    }
}
