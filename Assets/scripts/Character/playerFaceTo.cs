using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFaceTo : MonoBehaviour
{
    public Transform monster;
    public GameObject SC;

    SystemControl sc;

    private void Update()
    {
        sc = SC.GetComponent<SystemControl>();
        if (sc.state == BattleState.PLAYERTURN)
        {
            transform.LookAt(monster);
        }       
    }
}
