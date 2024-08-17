using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackVoice : MonoBehaviour
{
    public GameObject SC;
    public AudioSource music;

    SystemControl sc;


    void Start()
    {
        music = GetComponent<AudioSource>();
        music.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        sc = SC.GetComponent<SystemControl>();
        if (sc.hasUsedSkill == true)
        {
            music.enabled = true;
        }else
        {
            music.enabled=false;
        }
    }
}
