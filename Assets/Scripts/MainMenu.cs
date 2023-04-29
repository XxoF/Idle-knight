using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Scene");
        GameManager.instance.initState = true;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
