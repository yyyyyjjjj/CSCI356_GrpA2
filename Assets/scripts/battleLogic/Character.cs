using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // �˺�
    public int PlayerDamage;
    //�������ֵ
    public int maxHP;
    //Ŀǰ����ֵ
    public float currentHP;
    //����ƶ���
    public float movePower;
    //AI ����ֵ
    public int AiHP;
    //ai�˺�
    public int AiDamage;

    private void Update()
    {
        Debug.Log("Ŀǰ����ֵ: " + currentHP);
        Debug.Log("�ƶ���: " + movePower);
    }
}
