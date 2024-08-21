using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterFace : MonoBehaviour
{
    SystemControl sc;
    public GameObject SC;

    public Transform player;
    private void Update()
    {
        sc = SC.GetComponent<SystemControl>();
        if (sc.state == BattleState.ENEMTURN)
        {
            transform.LookAt(player);
        }
    }
}
