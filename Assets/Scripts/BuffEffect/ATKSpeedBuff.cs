using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ATKSpeedBuff")]
public class ATKSpeedBuff : PowerupEffect
{
    public int ATKSpeed_amount;

    public override void Apply(GameObject target)
    {
        Character targetCharacter = target.GetComponent<Character>();
        int currentSpeed = targetCharacter.GetATKSpeed();
        targetCharacter.SetATKSpeed(currentSpeed + ATKSpeed_amount);

        Debug.Log(targetCharacter.GetATKSpeed());
    }
}
