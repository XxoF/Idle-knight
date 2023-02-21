using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private int HP;



    private void Awake(){
        HP = baseHP;
    }

    public void TakeDamage(int enemy_dmg){
        //Debug.Log("Player dmg: " + enemy_dmg);

        // DR = Damage reduction
        float DR = (0.06f * armor) / (1f + 0.06f * armor);

        int dmg_received = Mathf.RoundToInt(enemy_dmg - enemy_dmg * DR);

        HP -= dmg_received;

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

    public int getDMG(){
        return damage;
    }

    public bool isDie(){
        if (HP <= 0) 
            return true;
        else
            return false;
    }
}
