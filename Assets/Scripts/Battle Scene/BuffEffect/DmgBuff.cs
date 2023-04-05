using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/DmgBuff")]

public class DmgBuff : PowerupEffect
{
    public int dmg_amount;

    public override void Apply(GameObject target)
    {
        Character targetCharacter = target.GetComponent<Character>();
        int currentDMG = targetCharacter.getDMG();
        targetCharacter.setDMG(currentDMG + dmg_amount);

        Debug.Log(targetCharacter.getDMG());
    }
}

