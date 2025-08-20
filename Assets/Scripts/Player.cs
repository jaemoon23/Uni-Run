using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Jump")]
    public float jumpForce = 10f;
    public int jumpCountMax = 2;

    private int jumpCount;
    private Animator animator;
    private Rigidbody2D rb;

    private bool isGrounded =true;
    private bool isDead = false;

    private GameManager gm;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.AddScore(10);
        }
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < jumpCountMax)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            ++jumpCount;
        }

        animator.SetBool("Grounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            jumpCount = 0;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.CompareTag("DeadZone"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        animator.SetTrigger("Die");
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;

        gm.OnPlayerDead();
    }
}
