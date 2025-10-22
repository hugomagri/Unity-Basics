using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f; // A velocidade do movimento, ajustada para o movimento para trás
    public float jumpForce = 7f; // Força do pulo
    public GameObject ground; // Referência ao chão (para paralaxe)

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    float horizontalMove = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimenta o chão (parallax)
        ground.transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Verifica o movimento do jogador
        float movimento = Input.GetAxisRaw("Horizontal");

        if (isGrounded) // Verifica se o personagem está no chão
        {
            if (movimento == 0)
            {
                // O personagem move-se junto com o cenário (parallax) quando não há input
                rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y); // Movimento contínuo para trás
                animator.SetFloat("Run", 0);
            }
            else
            {
                // Movimento do personagem com as teclas
                rb.linearVelocity = new Vector2(movimento * speed, rb.linearVelocity.y);
                animator.SetFloat("Run", Mathf.Abs(movimento));

                // Controla a direção do personagem
                if (movimento != 0)
                    transform.localScale = new Vector3(Mathf.Sign(movimento) * 0.24f, 0.24f, 0.24f);

            }
        }
        else
        {
            // Se o personagem não estiver no chão, ele não será puxado para trás
            rb.linearVelocity = new Vector2(movimento * speed, rb.linearVelocity.y);
        }

       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
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
