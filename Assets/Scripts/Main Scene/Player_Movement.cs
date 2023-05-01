using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed;

    //private float m_delayToIdle = 0.05f;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        float positionZ = transform.position.z;

        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0);

        //m_animator.SetInteger("AnimState", 1);
    }

}
