using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public GameObject HpUi;

    public Image HP;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP = HpUi.GetComponent<Image>();
        HpController();
    }

    void HpController()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        PlayerData player = playerObject.GetComponent<PlayerData>();

        // Update HP UI percentage
        
        float HpPercentage = player.currentHP / player.maxHP;
        Debug.Log("HpPercentage: " + HpPercentage);
        HP.fillAmount = HpPercentage;
        if (player.currentHP == 0)
        {
            animator.SetBool("Death", true);

        }
        else
        {
            animator.SetBool("Death", false);
        }
    }
}
