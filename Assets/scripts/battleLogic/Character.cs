using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 伤害
    public int PlayerDamage;
    //最大生命值
    public int maxHP;
    //目前生命值
    public float currentHP;
    //最大移动力
    public float movePower;
    //AI 生命值
    public int AiHP;
    //ai伤害
    public int AiDamage;

    private void Update()
    {
        Debug.Log("目前生命值: " + currentHP);
        Debug.Log("移动力: " + movePower);
    }
}
