using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isJump = false;
    Animator _animator;
    Rigidbody2D _rigidBody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && !_isJump)
        {
            _isJump = true;
            _animator.SetBool("Jump", true);
            _rigidBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isJump = false;
        _animator.SetBool("Jump", false);
    }
}
