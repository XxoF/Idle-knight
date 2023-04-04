using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    private GameObject battleSceneController;

    private GameObject player;
    private GameObject UpgradeUI;
    
    //private GameObject
    private void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UpgradeUI = GameObject.Find("UpgradeUI");
        battleSceneController = GameObject.Find("BattleSceneController");
    }

    public void OnClick()
    {
        
        
        powerupEffect.Apply(player);

        battleSceneController.GetComponent<BattleSceneController>().isUpgraded = true;
        UpgradeUI.SetActive(false);
        // Close upgradePanel after choosed



    }
}
