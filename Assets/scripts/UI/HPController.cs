using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public GameObject playerHpUi;
    public GameObject monsterHpUi;
    public GameObject SC;

    public Image playerHP;
    public Image monsterHP;
    SystemControl sc;

    public bool hasTakeDamage = false;


    public Animator animator;

    public bool times = false;

    float HpPercentage;



    // Start is called before the first frame update
    void Start()
    {
        sc = SC.GetComponent<SystemControl>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = playerHpUi.GetComponent<Image>();
        monsterHP = monsterHpUi.GetComponent<Image>();
        playerHpController();
        monster1HpController();
        
    }

    void playerHpController()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        PlayerData player = playerObject.GetComponent<PlayerData>();

        // Update HP UI percentage
        
        HpPercentage = player.currentHP / player.maxHP;
        playerHP.fillAmount = HpPercentage;

        if (sc.hasHeal == true && times == false)
        {
            player.currentHP += 10;
            times = true;
        }

        if (player.currentHP <= 0)
        {
            animator.SetBool("Death", true);

        }
        else
        {
            animator.SetBool("Death", false);
        }
    }
    void monster1HpController()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        PlayerData player = playerObject.GetComponent<PlayerData>();

        GameObject monsterObject = GameObject.FindWithTag("monster1");

        MonsterData monster = monsterObject.GetComponent<MonsterData>();

        float monsterHpPercentage = monster.AiCurrentHp / monster.AiMaxHp;

        monsterHP.fillAmount = monsterHpPercentage;

        if (sc.hasUsedSkill == true && hasTakeDamage == false)
        {
            monster.takenDamage(player.PlayerDamage);
            hasTakeDamage = true;
        }
        
        if (monster.AiCurrentHp <= 0)
        {
            animator.SetBool("Death", true);

        }
        else
        {
            animator.SetBool("Death", false);
        }

    }
}
