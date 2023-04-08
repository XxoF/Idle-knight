using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : MonoBehaviour
{

    public static Character instance;
    [SerializeField]
    protected new string name;

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

    

    private void Awake() {
        currentHP = baseHP;
    }

    private void dmgReceivedPopup(int dmgAmount)
    {
        DamagePopup.Create(dmgPopupPoint.position, dmgAmount);
    }

    public void TakeDamage(int enemy_dmg) {
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


        //Debug.Log(name + " received " + dmg_received + "dmg");
    }

    private void Die() {
        // Add action or trigger the restart game
    }

    public string getName() {
        return name;
    }

    public float get_Atk_rate() {
        return (float)ATK_Speed / (100 * BAT);
    }

    public float get_cd_ATK()
    {
        return 1 / get_Atk_rate();
    }

    public int getDMG() {
        return damage;
    }
    public int GetArmor()
    {
        return armor;
    }

    public void SetArmor(int value)
    {
        this.armor = value;
    }

    public void setDMG(int damage)
    {
        this.damage = damage;
    }
    public int getCurrentHP()
    {
        return currentHP;
    }

    public int getBaseHP()
    {
        return this.baseHP;
    }

    public void setBaseHP(int newHP)
    {
        this.baseHP = newHP;
    }
    public bool isDie() {
        return (currentHP <= 0);
    }

    public void Attack(Character target)
    {
        if (!this.isDie())
        {
            if (true)//target.enabled
            {
                if (playerAttackCurTime < this.get_cd_ATK())
                {
                    playerAttackCurTime += Time.deltaTime;
                }
                else
                {
                    this.gameObject.GetComponent<AnimatorController>().setIsAttack(true);
                    target.gameObject.GetComponent<AnimatorController>().setGotAttacked(true);
                    target.TakeDamage(this.damage);
                    playerAttackCurTime = 0;
                }
            }
        }

    }

    public int GetATKSpeed()
    {
        return ATK_Speed;
    }

    public void SetATKSpeed(int value)
    {
        ATK_Speed = value;
    }

    public void setDmgPopupPoint(Transform pos)
    {
        this.dmgPopupPoint = pos;
    }
}
