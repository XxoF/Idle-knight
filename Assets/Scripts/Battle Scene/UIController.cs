using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject playerGameObject, enemyGameObject;
    public TextMeshProUGUI playerHPText, enemyHPText;

    public Transform playerDmgPopupPoint, enemyDmgPopupPoint;
    public Transform playerPosition, enemyPosition;

    private Character player, enemy;

    void Awake()
    {
        playerDmgPopupPoint = GameObject.Find("PlayerDmgPopupPoint").transform;
        enemyDmgPopupPoint = GameObject.Find("EnemyDmgPopupPoint").transform;

        playerGameObject = GameManager.instance.player;
        enemyGameObject = GameManager.instance.enemy;

        player = playerGameObject.GetComponent<Character>();
        enemy = enemyGameObject.GetComponent<Character>();

        player.setDmgPopupPoint(playerDmgPopupPoint);
        enemy.setDmgPopupPoint(enemyDmgPopupPoint);

        playerGameObject.transform.position = GameObject.Find("PlayerPosition").transform.position;
        enemyGameObject.transform.position = GameObject.Find("EnemyPosition").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "HP: " + player.getCurrentHP() + "/" + player.getBaseHP();
        enemyHPText.text = "HP: " + enemy.getCurrentHP() + "/" + enemy.getBaseHP();
    }
}
