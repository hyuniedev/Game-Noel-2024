using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField]
    private float speedMovement = 10f;
    [SerializeField]
    private float jumpForce = 100f;

    private float horizontal;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
           horizontal = Input.GetAxis("Horizontal");
           Movement();
           if (CheckGrounded() && Input.GetKeyDown(KeyCode.Space))
           {
               rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
           }
    }

    private void Movement()
    {
        if (Mathf.Abs(horizontal) > 0)
        {
            rb.linearVelocity = new Vector2(horizontal * speedMovement, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }

    private bool CheckGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.2f, LayerMask.GetMask("Ground")).collider != null;
    }
}
