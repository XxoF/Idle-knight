using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnClick()
    {
        powerupEffect.Apply(player);

        // Close upgradePanel after choosed
        GameObject UpgradeUI = GameObject.FindGameObjectWithTag("UpgradeUI");
        UpgradeUI.SetActive(false);
    }
}
