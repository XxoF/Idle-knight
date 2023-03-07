using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ArmorBuff")]
public class ArmorBuff : PowerupEffect
{
    public int armor_amount;

    public override void Apply(GameObject target)
    {
        Character targetCharacter = target.GetComponent<Character>();
        int currentArmor = targetCharacter.GetArmor();
        targetCharacter.SetArmor(currentArmor + armor_amount);

        Debug.Log(targetCharacter.GetArmor());
    }
}
