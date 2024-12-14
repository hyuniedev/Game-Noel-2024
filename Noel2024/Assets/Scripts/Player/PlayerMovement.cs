using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private PlayerAnimation playerAnimation;
    [SerializeField]
    private float speedMovement = 10f;
    [SerializeField]
    private float jumpForce = 100f;

    public static bool IsDead;

    private float horizontal;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        IsDead = false;
        GameManager.Instance.OnPlayerDeath += Dead;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDeath -= Dead;
    }

    void Update()
    {
        playerAnimation.PlayAnimation(Mathf.Abs(horizontal),rb.linearVelocity.y, CheckGrounded(), IsDead);
        if (IsDead) return;
        
        horizontal = Input.GetAxisRaw("Horizontal");
        Movement();
        if (CheckGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            GameManager.Instance.EventJumped();
        }
    }
    
    private void Movement()
    {
        if (Mathf.Abs(horizontal) > 0)
        {
            rb.linearVelocity = new Vector2(horizontal * speedMovement, rb.linearVelocity.y);
            transform.localScale = new Vector3(horizontal, 1, 1);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap") && !IsDead)
        {
            GameManager.Instance.EventDeath();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            GameManager.Instance.EventCompleted();
            Invoke(nameof(NextLevel),0.8f);
        }
    }

    private void NextLevel()
    {
        GameManager.Instance.NextLevel();
    }

    private void Dead()
    {
        IsDead = true;
    }
}
