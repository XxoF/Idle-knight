using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    
    public float moveSpeed;
    public Vector3 moveVector;

    private Animator            m_animator;
    private float m_delayToIdle = 0.05f;
    
    void Start()
    {
        m_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        float positionZ = transform.position.z;
        transform.Translate(1 * moveSpeed * Time.deltaTime, 0, 0);

        m_animator.SetInteger("AnimState", 1);
    }
}
