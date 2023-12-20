using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_jumpSpeed;
    public float m_moveSpeed;
    private bool m_isJump = false;
    private bool m_isRunning = true;
    Animator m_animator;
    Rigidbody2D m_rigidBody;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (m_isJump)
        {
            m_animator.SetBool("Jump", true);
            m_rigidBody.AddForce(Vector2.up * m_jumpSpeed, ForceMode2D.Impulse);
            m_isJump = false;
        }
        m_rigidBody.position += new Vector2(m_moveSpeed * Time.fixedDeltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_isJump = false;
        m_animator.SetBool("Jump", false);
    }
}
