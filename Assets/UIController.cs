using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject playerGameObject, enemyGameObject;
    public TextMeshProUGUI playerHPText, enemyHPText;

    private PlayerCharacter player;
    private EnemyCharacter enemy;

    void Start()
    {
        player = playerGameObject.GetComponent<PlayerCharacter>();
        enemy = enemyGameObject.GetComponent<EnemyCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "HP: " + player.getCurrentHP() + "/" + player.getBaseHP();
        enemyHPText.text = "HP: " + enemy.getCurrentHP() + "/" + enemy.getBaseHP();
    }
}
