using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRoundBtn : MonoBehaviour
{
    public bool playerPassTurn = false;
    public Button EndRdButton;

    void Start()
    {
        // 将按钮的点击事件与OnClick方法关联起来
        EndRdButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        playerPassTurn = true;
    }
}
