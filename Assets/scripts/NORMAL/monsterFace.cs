using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterFace : MonoBehaviour
{

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
