using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    public GameObject playerGameObject, enemyGameObject;

    private float player_cd_atk;
    private float enemy_cd_atk;

    [SerializeField]
    private float playerAttackCurTime, enemyAttackCurtime;

    private PlayerCharacter player;
    private EnemyCharacter enemy;

    void Start()
    {

        player = playerGameObject.GetComponent<PlayerCharacter>();
        enemy = enemyGameObject.GetComponent<EnemyCharacter>();

        Debug.Log("Player: " + player.getName());
        Debug.Log("Enemy: " + enemy.getName());

        // AR = attack rate
        // Cooldown for attack = 1 / AR
        player_cd_atk = player.get_cd_ATK();
        enemy_cd_atk = enemy.get_cd_ATK();

        Debug.Log("Player CD: " + player_cd_atk);
        Debug.Log("Enemy CD: " + enemy_cd_atk);
    }

    // Update is called once per frame
    void Update()
    {

        // Player attack
        player.Attack(enemy);
        enemy.Attack(player);


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
