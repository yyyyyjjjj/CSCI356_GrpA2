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
        // ����ť�ĵ���¼���OnClick������������
        EndRdButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        playerPassTurn = true;
    }
}
