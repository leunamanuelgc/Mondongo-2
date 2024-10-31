using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Dash Settings")]
    public float dashForce = 20f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 1f;  // Tiempo de cooldown para el dash

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing;
    public bool canDash = true;
    private float horizontalInput;
    public float dashTime;
    public float dashCooldownTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dashCooldownTimer = 0;
    }

    private void Update()
    {
        // Obtener la entrada horizontal en Update
        horizontalInput = Input.GetAxis("Horizontal");

        // Verificar si el jugador está en el suelo usando la velocidad en Y
        isGrounded = Mathf.Abs(rb.velocity.y) < 0.1f;

        // Revisar si el jugador presiona el botón de salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Revisar si el jugador presiona el clic derecho para hacer el dash
        if (Input.GetMouseButtonDown(1) && canDash && !isDashing)
        {
            StartDash();
        }

        
    }

    private void FixedUpdate()
    {
        // Aplicar el movimiento horizontal en FixedUpdate
        if (isDashing)
        {
            UpdateDash();
        }
        else
        {
            // Aplicar el movimiento horizontal cuando no está en dash
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

            // Actualizar el cooldown del dash si es necesario
            if (!canDash)
            {
                dashCooldownTimer -= Time.fixedDeltaTime;
                if (dashCooldownTimer <= 0)
                {
                    canDash = true;
                }
            }
        }
    }

    private void Jump()
    {
        // Aplicar fuerza de salto en el eje Y
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void StartDash()
    {
        // Activar el dash
        isDashing = true;
        dashTime = dashDuration;

        // Aplicar una velocidad rápida en la dirección actual
        rb.velocity = new Vector2(horizontalInput * dashForce, rb.velocity.y);
    }

    private void UpdateDash()
    {
        // Reducir el tiempo de dash
        dashTime -= Time.fixedDeltaTime;
        if (dashTime <= 0)
        {
            // Desactivar el dash cuando el tiempo se agote
            isDashing = false;
            dashCooldownTimer = dashCooldown;
            canDash = false;
        }
    }
}
