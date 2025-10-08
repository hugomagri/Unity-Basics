using UnityEngine;

public class WallJump : MonoBehaviour
{
    public float velocidade = 5f;       // Velocidade lateral
    public float forcaPulo = 8f;        // Força do pulo normal
    public float forcaPuloParede = 10f; // Força aplicada ao pular da parede

    // Checagem de chão e parede
    public Transform checarChao;
    public Transform checarParede;
    public LayerMask chaoLayer;
    public LayerMask paredeLayer;
    public float raioChecagem = 0.2f;

    private Rigidbody2D rb;
    private bool estaNoChao;
    private bool encostadoParede;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal normal
        float movimento = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        // Detecta se está no chão e se encosta na parede
        estaNoChao = Physics2D.OverlapCircle(checarChao.position, raioChecagem, chaoLayer);
        encostadoParede = Physics2D.OverlapCircle(checarParede.position, raioChecagem, paredeLayer);

        // Pulo comum
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
        // Pulo na parede (Wall Jump)
        else if (Input.GetKeyDown(KeyCode.Space) && encostadoParede)
        {
            // Inverte a direção ao pular
            float direcao = -Mathf.Sign(transform.localScale.x);
            rb.linearVelocity = new Vector2(direcao * forcaPuloParede, forcaPuloParede);
        }

        // Espelha o sprite
        if (movimento != 0)
            transform.localScale = new Vector3(Mathf.Sign(movimento), 1, 1);
    }

    // Mostra as áreas de checagem no editor
    void OnDrawGizmosSelected()
    {
        if (checarChao)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(checarChao.position, raioChecagem);
        }
        if (checarParede)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(checarParede.position, raioChecagem);
        }
    }
}
