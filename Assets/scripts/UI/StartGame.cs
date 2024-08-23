using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
      public void LoadGame()
    {
        SceneManager.LoadScene("MountainScene");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene(3);
    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
