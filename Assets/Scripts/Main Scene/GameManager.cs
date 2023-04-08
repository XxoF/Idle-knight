using System.Collections;
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

    private Player_Movement player_mv;

    private List<GameObject> enemyList;
    private int enemyCount = 0;

    [SerializeField]
    private static float xInit = -35f;
    [SerializeField]
    private static float yInit = 4.5f;
    [SerializeField]
    private static float zInit = 1f;

    [Range(10f, 100f)]
    [SerializeField]
    private static float enemyRange = 50f;

    [SerializeField]
    public static Vector3 playerPos = new Vector3(xInit, yInit, zInit);

    //[SerializeField]
    //private static Vector3 enemySpawnPosition = playerPos + new Vector3(enemyRange, 0f, 0f);

    [SerializeField]
    private bool initState = true;
    //private static float PLAYER_SPEED = 20F;
    //private float playerSpeed;

    [SerializeField]
    private Transform playerSpawnPosition;

    [SerializeField]
    private Transform enemySpawnPosition;

    public enum GameStates
    {
        INIT_STATE,
        WORLD_STATE,
        BATTLE_STATE,
        IDLE_STATE
    }

    public GameStates gameState;

    private void Start()
    {
        if (initState == true)
        {
            initState = false;
            SpawnPlayer(playerSpawnPosition.position);
            player = GameObject.FindGameObjectWithTag("Player");
        }
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

        gameState = GameStates.IDLE_STATE;
        //player_mv = player.GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case (GameStates.WORLD_STATE):

                isWalking = true;
                //Debug.Log("WORLD STATE");


                SpawnEnemy();

                enemy = GameObject.FindGameObjectWithTag("Enemy");
                

                if (gotAttacked)
                {
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

                if (isPlayerAlive)
                {
                    Destroy(enemy);
                }

                player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = playerSpawnPosition.position;

                isWalking = false;
                endBattle = false;
                gotAttacked = false;
                gameState = GameStates.WORLD_STATE;

                break;         
        }
    }

    public void StartBattle()
    {
        print("STart battle");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(enemy);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(playerSpawnPosition);
        DontDestroyOnLoad(enemySpawnPosition);
        isWalking = false;
        SceneManager.LoadScene("Battle_Scene");
        gotAttacked = false;

    }

    void SpawnPlayer(Vector3 pos)
    {

        print("Spawn player");
        string playerPrefabPath = "Assets/Resources/Prefabs/Player.prefab";

        var playerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(playerPrefabPath);

        Instantiate(playerPrefab, pos, Quaternion.identity);

    }


    void SpawnEnemy()
    {
       
        string enemyPrefabPath = "Assets/Resources/Prefabs/Enemy.prefab";

        var enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(enemyPrefabPath);

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount <= 0)
        {
            Instantiate(enemyPrefab, enemySpawnPosition.position, Quaternion.identity);
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
