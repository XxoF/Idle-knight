using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject enemy;

    public bool isWalking = false;
    public bool isPlayerAlive = false;
    public bool gotAttacked = false;

    private Player_Movement player_mv;

    //private static float PLAYER_SPEED = 20F;
    //private float playerSpeed;

    public enum GameStates
    {
        WORLD_STATE,
        BATTLE_STATE,
        IDLE_STATE
    }

    public GameStates gameState;

    private void Start()
    {
        isPlayerAlive = true;
        gameState = GameStates.IDLE_STATE;

    }

    private void Awake()
    {
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

                player = GameObject.FindGameObjectWithTag("Player");
                enemy = GameObject.FindGameObjectWithTag("Enemy");

                if (isWalking)
                {
                    //player.GetComponent<Player_Movement>().moveSpeed = 20f;
                }
                if (gotAttacked)
                {
                    gameState = GameStates.BATTLE_STATE;
                }

                break;

            case (GameStates.BATTLE_STATE):
                //player stop moving
                player.GetComponent<Player_Movement>().moveSpeed = 0f;

                // LOAD BATTLE SCENCE
                StartBattle();

                // TURN TO IDLE after battle
                gameState = GameStates.IDLE_STATE;
                break;

            case (GameStates.IDLE_STATE):
                
                if (isPlayerAlive)
                {
                    isWalking = true;
                    gotAttacked = false;
                    gameState = GameStates.WORLD_STATE;
                }
                break;
        }
    }

    public void StartBattle()
    {
        print("STart battle");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(enemy);
        DontDestroyOnLoad(gameObject);
        isWalking = false;
        SceneManager.LoadScene("Battle_Scene");
        gotAttacked = false;

    }
}
