using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HPBuff")]
public class HPBuff : PowerupEffect
{
    public int HP_amount;

    public override void Apply(GameObject target)
    {
        Character targetCharacter = target.GetComponent<Character>();
        int currentHP = targetCharacter.getBaseHP();
        targetCharacter.setBaseHP(currentHP + HP_amount);

        Debug.Log(targetCharacter.getBaseHP());
    }
}
