using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSetBar : MonoBehaviour
{
    //传入脚本数据
    public Image HpImage;
    Character player;

    //获取对象
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
