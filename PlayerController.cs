using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    private float speed;

    private bool facingPlayerRight;
    private bool isGrounded;
    private bool jump;

    [SerializeField]
    private Transform[] groundCheckPoints;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private float jumpForce;

    private LayerMask checkWhatIsGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingPlayerRight = true;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Movement(horizontal);
        PlayerDirection(horizontal);

        isGrounded = IsGrounded();
    }

    private void Movement(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        anim.SetFloat("Run", Mathf.Abs(horizontal));

        if((isGrounded) && (jump))
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void PlayerDirection(float horizontal)
    {
        if((horizontal > 0) && (!facingPlayerRight) || (horizontal < 0) && (facingPlayerRight))
        {
            facingPlayerRight = !facingPlayerRight;

            Vector3 Scale = transform.localScale;

            Scale.x *= -1;

            transform.localScale = Scale;
        }
    }

    private bool IsGrounded()
    {
        if(rb.velocity.y <= 0)
        {
            foreach(Transform point in groundCheckPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundCheckRadius, checkWhatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
