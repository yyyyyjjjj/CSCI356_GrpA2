using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Button WIN;
    public Canvas restart;

    private void Start()
    {
        //WIN.onClick.AddListener(OnbuttonClick);
        restart.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject monster = GameObject.FindWithTag("monster1");
        MonsterData Monster = monster.GetComponent<MonsterData>();

        if (Monster.AiCurrentHp <= 0)
        {
            restart.enabled = true;
        }
    }

    // public void OnbuttonClick()
    // {
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    // }
}
