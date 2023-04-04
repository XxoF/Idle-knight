using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBattle : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    private bool spawning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad (gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle_Scene")
        {
            if (spawning)
            {
                Instantiate(enemyPrefab);
            }
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Player trigger enemy encounter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            print("Trigger battle");
            GameManager.instance.gotAttacked = true;
        }
    }

}
