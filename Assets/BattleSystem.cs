using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private float player_cd_atk;
    private float enemy_cd_atk;

    public float playerAttackCurTime = 0;
    public float enemyAttackCurTime = 0;

    PlayerCharacter player;
    EnemyCharacter enemy;
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<PlayerCharacter>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyCharacter>();

        Debug.Log("Player: " + player.getName());
        Debug.Log("Enemy: " + enemy.getName());

        // AR = attack rate
        // Cooldown for attack = 1 / AR
        player_cd_atk = 1 / player.get_Atk_rate();
        enemy_cd_atk = 1 / enemy.get_Atk_rate();

        Debug.Log("Player CD: " + player_cd_atk);
        Debug.Log("Enemy CD: " + enemy_cd_atk);
    }

    // Update is called once per frame
    void Update()
    {
  
        // Player attack
        if (player.enabled == true){
            if (playerAttackCurTime < player_cd_atk){
                playerAttackCurTime += Time.deltaTime;
            }
            else if (enemy.enabled == true){
                int playerDMG = player.getDMG();
                enemy.TakeDamage(playerDMG);
                playerAttackCurTime = 0;
            }
        }
        

        // Enemy attack
        if (enemy.enabled == true){
            if (enemyAttackCurTime < enemy_cd_atk){
                enemyAttackCurTime += Time.deltaTime;
            }
            else if (player.enabled == true){
                int enemyDMG = enemy.getDMG();
                player.TakeDamage(enemyDMG);
                enemyAttackCurTime = 0;
            }
        }
        


        // Check if enemy is killed
        if ((enemy.isDie()) && (enemy.enabled == true)){
            Debug.Log("Enemy killed");
            enemy.enabled = false;
        }

        // Check if player is killed
        if ((player.isDie()) && (player.enabled == true)){
            Debug.Log("Enemy killed");
            player.enabled = false;
        }


    }
}
