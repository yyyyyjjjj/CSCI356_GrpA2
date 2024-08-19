using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFaceTo : MonoBehaviour
{
    public Transform monster;

    private void Update()
    {
        transform.LookAt(monster);
    }
}
