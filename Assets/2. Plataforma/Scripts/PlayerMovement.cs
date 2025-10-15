using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal");

        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (movimento != 0)
            transform.localScale = new Vector3(Mathf.Sign(movimento) * 0.18f, 0.18f, 0.18f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.contacts[0].normal.y > 0.5f)
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }
}