using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerStomp : MonoBehaviour
{
    [Header("Configurações do Stomp")]
    public float forcaRebote = 8f;   // Força do pulo ao pisar no inimigo
    public float danoInimigo = 10f;  // Dano causado ao inimigo
    public float danoPlayer = 10f;   // Dano que o player recebe ao encostar pelos lados

    private Rigidbody2D rb;          // Referência ao Rigidbody2D do Player
    private Vida vidaPlayer; // Script de vida do Player

    void Start()
    {
        // Pega o Rigidbody2D e o script de vida
        rb = GetComponent<Rigidbody2D>();
        vidaPlayer = GetComponent<Vida>();
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        // Verifica se colidiu com um inimigo
        if (colisao.collider.CompareTag("Inimigo"))
        {
            // Normal do ponto de contato
            Vector2 normal = colisao.contacts[0].normal;

            if (normal.y > 0.5f)
            {
                // Colisão de cima → stomp
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaRebote);

                // Aplica dano no inimigo
                Vida inimigoVida = colisao.collider.GetComponent<Vida>();
                inimigoVida?.ReceberDano(danoInimigo);
            }
            else
            {
                // Colisão lateral ou de baixo → player recebe dano
                vidaPlayer?.ReceberDano(danoPlayer);
            }
        }
    }
}
