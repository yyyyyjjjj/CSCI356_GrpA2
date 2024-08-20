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


   
    public GameObject player;
    public Animator playerAnimation;
    public GameObject monster;
    public Animator monsterAnimation;

    public bool times = false;

    

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = player.GetComponent<Animator>();
        monsterAnimation = monster.GetComponent<Animator>();
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
        
        float HpPercentage = player.currentHP / player.maxHP;
        playerHP.fillAmount = HpPercentage;

        if (sc.hasHeal == true && times == false)
        {
            player.currentHP += 10;
            times = true;
        }

        if (player.currentHP <= 0)
        {
            playerAnimation.SetTrigger("Death");

        }
        else
        {
            playerAnimation.ResetTrigger("Death");
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
            monsterAnimation.SetBool("Death", true);

        }
        else
        {
            monsterAnimation.SetBool("Death", false);
        }

    }
}
