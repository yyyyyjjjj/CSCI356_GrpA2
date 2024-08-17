using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator anim;
    Rigidbody Rigidbody;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        setAnimation();
    }

    public void setAnimation()
    {
        anim.SetBool("move",true);
    }
}
