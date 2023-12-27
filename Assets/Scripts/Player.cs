using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_jumpForce;
    public float m_moveSpeed;
    private bool m_needJump = false;
    private bool m_canJump = true;
    private bool m_canDoubleJump = true;
    Animator m_animator;
    Rigidbody2D m_rigidBody;
    public Camera m_camera;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_needJump = true;
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                m_needJump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (m_needJump)
        {
            m_needJump = false;
            if (m_canJump)
            {
                m_canJump = false;
                m_animator.SetBool("Jump", true);
                m_animator.SetBool("Run", false);
                m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, m_jumpForce);
            }
            else if (m_canDoubleJump)
            {
                m_canDoubleJump = false;
                m_animator.SetBool("Jump", true);
                m_animator.SetBool("Run", false);
                m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, m_jumpForce);
            }
        }

        var offset = m_camera.transform.position.x - transform.position.x;
        m_rigidBody.velocity = new Vector2(m_moveSpeed + offset, m_rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_canJump = true;
        m_canDoubleJump = true;
        m_animator.SetBool("Run", true);
        m_animator.SetBool("Jump", false);
    }
}
