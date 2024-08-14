using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musicControl : MonoBehaviour
{
    SystemControl sc;
    public GameObject SC;

    public AudioSource NormalBGM;
    public AudioSource battleBGM;

    private void Update()
    {
        sc = SC.GetComponent<SystemControl>();
        if (sc.state == BattleState.NORMAL)
        {
            NormalBGM.enabled = true;
            battleBGM.enabled = false;
        }else if (sc.state == BattleState.PLAYERTURN)
        {
            NormalBGM.enabled = false;
            battleBGM.enabled = true;
        }
    }
}
