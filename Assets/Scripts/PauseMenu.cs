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
            

        DestroyAllGameObjects();

        Time.timeScale = 1f;


    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void DestroyAllGameObjects()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 2; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
            Debug.Log(GameObjects[i]);
        }
    }
}
