using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSetBar : MonoBehaviour
{
    //����ű�����
    public Image HpImage;
    Character player;

    //��ȡ����
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        player = Player.GetComponent<Character>();



    }

    public void OnHealthChange(float Percentage)
    {
        HpImage.fillAmount = Percentage;
    }
}
