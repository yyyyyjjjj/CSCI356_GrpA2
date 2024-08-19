using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFaceTo : MonoBehaviour
{
    public GameObject SC;
    public Transform monster;
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
