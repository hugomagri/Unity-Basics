using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento
    private Rigidbody2D rb;       // Referência ao Rigidbody2D
    private Vector2 moveInput;    // Entrada do jogador (WASD ou setas)

    void Start()
    {
        // Obtém o Rigidbody2D do objeto
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura entrada horizontal e vertical
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normaliza o vetor para que a diagonal não fique mais rápida
        moveInput.Normalize();

        // Opcional: gira o jogador na direção do movimento
        if (moveInput.sqrMagnitude > 0.01f)
        {
            float angulo = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo - 90f);
        }
    }

    void FixedUpdate()
    {
        // Aplica a velocidade diretamente ao Rigidbody2D
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
