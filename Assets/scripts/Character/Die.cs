using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public Button RESTART;
    public Canvas restart;

    private void Start()
    {
        RESTART.onClick.AddListener(OnbuttonClick);
        restart.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerData Player = player.GetComponent<PlayerData>();

        GameObject monster = GameObject.FindWithTag("monster1");
        MonsterData Monster = player.GetComponent<MonsterData>();

        if (Player.currentHP <= 0 && Monster.AiCurrentHp > 0)
        {
            restart.enabled = true;
        }        
    }

    public void OnbuttonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
