using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
    public Image powerImage;
    private ClickToMoveBattle move;
    private ClickToMove noBtMove;
    public GameObject Player;
   
    private void Update()
    {
        powerImage = GetComponent<Image>();
        move = Player.GetComponent<ClickToMoveBattle>();
        noBtMove = Player.GetComponent<ClickToMove>();
        
        if (noBtMove.stop == true)
        {
            float percentage = 1;
            powerImage.fillAmount = percentage;
            noBtMove.stop = false;
        }
        else {
            float percentage = move.percentage;
            powerImage.fillAmount = percentage;
        }                   
    }
}
