using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    private bool isDashing;
    private bool isWalking;
    private float lookDirection = 1f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public InputActionReference move;
    // public Animator animator;

    [Header("Walk")]
    public float moveSpeed = 70f;



    private void Awake()
    {
        Application.targetFrameRate = -1;
    }

    void Update()
    {
        if (isDashing) return;

        moveDirection = move.action.ReadValue<Vector2>();
        WalkingCheck();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        if (isDashing) return;
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed), ForceMode2D.Force);
    }

    // Flip sprite depending on move direction (left or right)
    private void FlipSprite()
    {
        if (moveDirection.x < 0f)
        {
            sr.flipX = true;
            lookDirection = -1f;

        }
        else if (moveDirection.x > 0f)
        {
            sr.flipX = false;
            lookDirection = 1f;
        }
    }
    private void WalkingCheck()
    {
        if (moveDirection.x != 0f || moveDirection.y != 0f)
        {
            isWalking = true;
            // animator.SetBool("isWalking", isWalking);
        }
        else
        {
            isWalking = false;
            // animator.SetBool("isWalking", isWalking);
        }
    }

    public void DisableHurtAnimation()
    {
        // animator.SetBool("isHurt", false);
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }
}
