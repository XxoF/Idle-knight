using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    public static AnimatorController instance;

    public Animator animator;
    // Start is called before the first frame update


    public bool isAttack = false;
    public bool gotAttacked = false;

    void Update()
    {

        animator.SetBool("isWalking", GameManager.instance.isWalking);

        if (isAttack)
        {
            animator.SetTrigger("isAttack");
            isAttack = false;
        }

        if (gotAttacked)
        {
            animator.SetTrigger("gotAttacked");
            gotAttacked = false;
        }
    }


    public void setIsAttack(bool state)
    {
        this.isAttack = state;
    }

    public void setGotAttacked(bool state)
    {
        this.gotAttacked = state;
    }
}
