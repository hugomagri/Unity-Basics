using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f; // A velocidade do movimento do personagem
    public float parallaxSpeed = 0.5f; // A velocidade do paralaxe
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
        // Movimenta o chão (parallax) com uma velocidade diferente da do personagem
        ground.transform.Translate(Vector2.left * parallaxSpeed * Time.deltaTime);

        // Verifica o movimento do jogador
        float movimento = Input.GetAxisRaw("Horizontal");

        // Quando o jogador se move (seja no ar ou no chão), ele muda a escala para virar
        if (movimento != 0)
        {
            // Controla a direção do personagem, virando para a esquerda ou direita
            transform.localScale = new Vector3(Mathf.Sign(movimento) * 0.25f, 0.25f, 0.25f);
        }

        if (isGrounded) // Verifica se o personagem está no chão
        {
            if (movimento == 0)
            {
                // O personagem move-se junto com o cenário (parallax) quando não há input
                rb.linearVelocity = new Vector2(-parallaxSpeed, rb.linearVelocity.y); // Movimento contínuo para trás
                animator.SetFloat("Run", 0);
            }
            else
            {
                // Quando o personagem anda para frente
                if (movimento > 0)
                {
                    rb.linearVelocity = new Vector2(movimento * speed, rb.linearVelocity.y);
                }
                // Quando o personagem anda para trás
                else if (movimento < 0)
                {
                    rb.linearVelocity = new Vector2((movimento * speed) - parallaxSpeed, rb.linearVelocity.y); // Movimento para trás com a velocidade combinada
                }

                animator.SetFloat("Run", Mathf.Abs(movimento));
            }
        }
        else
        {
            // Se o personagem não estiver no chão, ele não será puxado para trás
            rb.linearVelocity = new Vector2(movimento * speed, rb.linearVelocity.y);
        }

        // Controle de pulo
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
