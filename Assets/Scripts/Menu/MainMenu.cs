using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        AudioListener.pause = false;
        AudioManager.instance.Play("Theme");
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Main_Scene");
        GameManager.instance.initState = true;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");

        GameObject audioManager = GameObject.FindGameObjectWithTag("Audio");
        Destroy(audioManager);

        Application.Quit();
    }
}
