using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Character : MonoBehaviour
{

    [SerializeField]
    protected string firstname;

    [SerializeField]
    protected int damage;

    [SerializeField]
    // Base Attack Time
    protected float BAT;

    [SerializeField]
    protected int ATK_Speed;

    [SerializeField]
    protected int armor;

    [SerializeField]
    protected int baseHP;

    [SerializeField]
    protected bool isPlayer;

    [SerializeField]
    protected GameObject dmgReceivedText;

    [SerializeField]
    protected Transform dmgPopupPoint;

    [SerializeField]
    private int currentHP;
    private float playerAttackCurTime = 0;


    private void Awake(){
        currentHP = baseHP;
    }

    private void dmgReceivedPopup(int dmgAmount)
    {
        DamagePopup.Create(dmgPopupPoint.position, dmgAmount);
    }

    public void TakeDamage(int enemy_dmg){
        //Debug.Log("Player dmg: " + enemy_dmg);

        // DR = Damage reduction
        float DR = (0.06f * armor) / (1f + 0.06f * armor);

        int dmg_received = Mathf.RoundToInt(enemy_dmg - enemy_dmg * DR);
        dmgReceivedPopup(dmg_received);


        if (currentHP >= dmg_received)
        {
            currentHP -= dmg_received;
        }
        else
        {
            currentHP = 0;
        }
           

        Debug.Log(firstname + " received " + dmg_received + "dmg");
    }

    private void Die(){
        // Add action or trigger the restart game
    }

    public string getName(){
        return firstname;
    }

    public float get_Atk_rate(){
        return (float) ATK_Speed / (100 * BAT);
    }

    public float get_cd_ATK()
    {
        return 1 / get_Atk_rate();
    }

    public int getDMG(){
        return damage;
    }

    public int getCurrentHP()
    {
        return currentHP;
    }

    public int getBaseHP()
    {
        return baseHP;
    }

    public bool isDie(){
        return (currentHP <= 0);
    }

    public void Attack(Character target)
    {
        if (!this.isDie())
        {
            if (target.enabled)
            {
                if (playerAttackCurTime < this.get_cd_ATK())
                {
                    playerAttackCurTime += Time.deltaTime;
                }
                else
                {
                    target.TakeDamage(this.damage);
                    playerAttackCurTime = 0;
                }
            }
        }
        
    }
}
