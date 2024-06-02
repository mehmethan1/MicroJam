using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public ParticleSystem particle;


    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTime;
    private float lastDashTime;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing)
        {
            if (Time.time >= dashTime)
            {
                isDashing = false;
                rb.velocity = Vector2.zero;
            }
            return;
        }
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed;

        if (movement.x != 0 || movement.y != 0) { particle.Play(); animator.Play("Run"); }
        else if (movement.x == 0 || movement.y == 0) { animator.Play("idle"); particle.Stop(); }

        if (Input.GetButtonDown("Dash1") && Time.time >= lastDashTime + dashCooldown)
        {
            StartDash(movement);
        }
    }

    void StartDash(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            isDashing = true;
            dashTime = Time.time + dashDuration;
            lastDashTime = Time.time;
            rb.velocity = direction.normalized * dashSpeed;
        }
    }
}
