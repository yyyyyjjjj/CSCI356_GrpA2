using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // damage
    public int PlayerDamage;
    //max hp
    public int maxHP;
    //current hp
    public float currentHP;
    //move power
    public float movePower;

    public void takenDamage(int damage)
    {
        currentHP -= damage;
    }
}
