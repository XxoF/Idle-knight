using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleSceneController : MonoBehaviour
{
    public static BattleSceneController instance;

    public GameObject playerGameObject, enemyGameObject;

    public bool isUpgraded = false;

    private float player_cd_atk;
    private float enemy_cd_atk;

    [SerializeField]
    private float playerAttackCurTime, enemyAttackCurtime;

    public Character player, enemy;

    private GameObject UpgradeUI;
    private GameObject DeadMenuUI;

    public enum BattleState
    {
        BATTLE,
        WIN,
        LOSE,
        OUT_BATTLE,
    }

    public BattleState battleState;

    private void Start()
    {

    }

    void Awake()
    {
        playerGameObject = GameManager.instance.player;
        enemyGameObject = GameManager.instance.enemy;

        player = playerGameObject.GetComponent<Character>();
        enemy = enemyGameObject.GetComponent<Character>();


        Debug.Log("Player: " + player.getName());
        Debug.Log("Enemy: " + enemy.getName());

        // AR = attack rate
        // Cooldown for attack = 1 / AR
        player_cd_atk = player.get_cd_ATK();
        enemy_cd_atk = enemy.get_cd_ATK();

        Debug.Log("Player CD: " + player_cd_atk);
        Debug.Log("Enemy CD: " + enemy_cd_atk);

        UpgradeUI = GameObject.FindGameObjectWithTag("UpgradeUI");
        DeadMenuUI = GameObject.Find("Dead Menu");

        UpgradeUI.SetActive(false);
        DeadMenuUI.SetActive(false);

        battleState = BattleState.BATTLE;
        isUpgraded = false;
    }

    // Update is called once per frame
    void Update()
    {

        switch (battleState)
        {
            case (BattleState.BATTLE):
                player.Attack(enemy);
                //PlayerAnimatorController.instance.isAttack = true;
                enemy.Attack(player);

                if ((enemy.isDie())/* && (enemy.enabled == true)*/)
                {
                    Debug.Log("Player win");
                    //enemy.GetComponent<AnimatorController>().setIsDied(true);
                    battleState = BattleState.WIN;
                    //enemy.enabled = false;
                }

                if ((player.isDie())/* && (player.enabled == true)*/)
                {
                    Debug.Log("Player Lose");
                    //player.GetComponent<AnimatorController>().setIsDied(true);
                    GameManager.instance.isPlayerAlive = false;
                    battleState = BattleState.LOSE;
                    //player.enabled = false;
                }

                break;

            case (BattleState.WIN):
                //Debug.Log("Player win");

                if (!isUpgraded)
                {
                    if (UpgradeUI.activeSelf == false)
                    {
                        UpgradeUI.SetActive(true);
                    }
                        
                }
                else
                {
                    //UpgradeUI.SetActive(false);
                    battleState = BattleState.OUT_BATTLE;
                }
                
                break;

            case (BattleState.LOSE):
                Debug.Log("Player lose");
                DeadMenuUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case (BattleState.OUT_BATTLE):
                GameManager.instance.gameState = GameManager.GameStates.IDLE_STATE;
                GameManager.instance.endBattle = true;
                SceneManager.LoadScene("Main_Scene");
                break;


        }

    }

    public void setIsUpgrade(bool state)
    {
        this.isUpgraded = state;
    }
}
