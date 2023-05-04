﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject enemy;

    public Animator playerAnimation; 
    public bool isWalking = false;
    public bool isPlayerAlive = true;
    public bool gotAttacked = false;
    public bool endBattle = false;

    [SerializeField]
    private static float xInit = -35f;
    [SerializeField]
    private static float yInit = 4.5f;
    [SerializeField]
    private static float zInit = 1f;

    //[Range(10f, 100f)]
    //[SerializeField]
    //private static float enemyRange = 50f;

    [SerializeField]
    public static Vector3 playerPos = new Vector3(xInit, yInit, zInit);

    //[SerializeField]
    //private static Vector3 enemySpawnPosition = playerPos + new Vector3(enemyRange, 0f, 0f);

    [SerializeField]
    public bool initState = true;
    //private static float PLAYER_SPEED = 20F;
    //private float playerSpeed;

    /*
    [SerializeField]
    private Transform playerSpawnPosition;

    [SerializeField]
    private Transform enemySpawnPosition;
    */

    private static Vector3 playerSpawnPosition = new Vector3(-35, 1.5f, 0);
    private static Vector3 enemySpawnPosition = new Vector3(0f, 5f, 0);

    public enum GameStates
    {
        INIT_STATE,
        WORLD_STATE,
        BATTLE_STATE,
        IDLE_STATE
    }

    public GameStates gameState = GameStates.INIT_STATE;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public List<GameObject> enemyListPrefab;

    private void Start()
    {
        Debug.Log("Start game");
    }

    private void Awake()
    {

        Debug.Log("Awake!");
        initState = true;

        // Check if instance exist
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //player_mv = player.GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case (GameStates.WORLD_STATE):

                isWalking = true;
                player.GetComponent<AnimatorController>().isWalking = isWalking;
                //Debug.Log("WORLD STATE");


                SpawnEnemy();

                enemy = GameObject.FindGameObjectWithTag("Enemy");
                

                if (gotAttacked)
                {
                    initState = false;
                    gameState = GameStates.BATTLE_STATE;
                    enemy.GetComponent<Player_Movement>().moveSpeed = 0f;
                    StartBattle();      
                }

                break;

            case (GameStates.BATTLE_STATE):
                //player stop moving
                //Debug.Log("BATTLE STATE");

                // LOAD BATTLE SCENCE
                if (endBattle)
                {
                    gameState = GameStates.IDLE_STATE;
                }

                // TURN TO IDLE after battle
                break;

            case (GameStates.IDLE_STATE):
                //Debug.Log("IDLE STATE");
                // After battle
                if (AudioManager.instance != null)
                    AudioManager.instance.Unpause("Theme");

                if (!initState)
                {
                    Scene mainScene = SceneManager.GetSceneByName("Main_Scene");
                    SceneManager.MoveGameObjectToScene(player, mainScene);
                    SceneManager.MoveGameObjectToScene(gameObject, mainScene);
                }
                


                if (isPlayerAlive)
                {
                    Destroy(enemy);
                }

                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Character>().updateCurrentHP();

                player.transform.position = playerSpawnPosition;

                isWalking = false;
                player.GetComponent<AnimatorController>().isWalking = isWalking;

                endBattle = false;
                gotAttacked = false;
                gameState = GameStates.WORLD_STATE;




                break;

            case (GameStates.INIT_STATE):
                if (!player)
                {
                    SpawnPlayer(playerSpawnPosition);
                    player = GameObject.FindGameObjectWithTag("Player");
                    player.GetComponent<Character>().updateCurrentHP();
                }

                gameState = GameStates.IDLE_STATE;
                break;
        }
    }

    public void StartBattle()
    {
        print("Start battle");

        /*
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Battle_Scene"));
        SceneManager.MoveGameObjectToScene(enemy, SceneManager.GetSceneByName("Battle_Scene"));
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName("Battle_Scene"));
        */

        SceneManager.LoadSceneAsync("Battle_Scene");


        DontDestroyOnLoad(player);
        DontDestroyOnLoad(enemy);
        DontDestroyOnLoad(gameObject);
  

        isWalking = false;
        player.GetComponent<AnimatorController>().isWalking = isWalking;

        gotAttacked = false;

    }

    void SpawnPlayer(Vector3 pos)
    {

        print("Spawn player");

        Instantiate(playerPrefab, pos, Quaternion.identity);

    }


    void SpawnEnemy()
    {

        int numberEnemyPrefab = enemyListPrefab.Count;

        int randomIndexEnemy = Random.Range(0, numberEnemyPrefab);

        enemyPrefab = enemyListPrefab[randomIndexEnemy];


        if (enemy == null)
        {
            Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);
        }
        
        // Spawn enemy cách player 1 đoạn
        // Lấy stats enemy từ trong list Character/Enemy
        // Lựa chọn ngẫu nhiên enemy
        // Enemy có nên mạnh hơn?
        // Chỉ spawn 1-2 enemy trên map.
        // Ngừng spawn khi đang battle?
    }

    void spawnNewEnemy(GameObject enemy, Transform position)
    {
        
    }


}
