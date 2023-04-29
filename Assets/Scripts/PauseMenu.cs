using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    public void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Load Menu");
        gameIsPause = false;

        SceneManager.LoadSceneAsync("Menu_Scene");


        DestroyAllRemainGameObjects();

        Time.timeScale = 1f;


    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void DestroyAllRemainGameObjects()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        Destroy(gameManager);
        Destroy(player);
        Destroy(enemy);
    }
}
