using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackVoice : MonoBehaviour
{
    public GameObject SC;
    public AudioSource audioSource;
    public AudioClip attackClip;
    public AudioClip fireClip;
    public AudioClip lightningClip;
    public AudioClip lightningClip2;


    SystemControl sc;

    //play one times
    public bool oneTimes = false;

    void Start()
    {
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        sc = SC.GetComponent<SystemControl>();
        if (sc.hasUsedSkill)
        {
            audioSource.clip = attackClip;
        }
        else if (sc.hasUsedFireBall)
        {
            audioSource.clip = fireClip;
        }
        else if (sc.hasUsedLightning)
        {
            audioSource.clip = lightningClip;
        }
        else if (sc.hasHeal)
        {
            Debug.Log("heal");
            audioSource.clip = lightningClip2;
        }
        else
        {
            audioSource.clip = null; 
        }

        // ≤•∑≈ªÚÕ£÷π“Ù∆µ
        if (audioSource.clip != null)
        {
            if (!audioSource.isPlaying && oneTimes == false)
            {
                audioSource.Play();
                oneTimes = true;
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
