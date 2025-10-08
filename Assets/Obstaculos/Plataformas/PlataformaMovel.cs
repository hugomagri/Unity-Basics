using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    [Header("Movimento")]
    public Transform pontoA; // Ponto inicial do percurso
    public Transform pontoB; // Ponto final do percurso
    public float velocidade = 2f; // Velocidade da plataforma

    private Vector3 alvo;           // Posição atual do destino (A ou B)
    private Vector3 ultimaPosicao;  // Posição anterior da plataforma
    private Vector3 deslocamento;   // Quanto a plataforma se moveu entre frames

    private GameObject jogadorEmCima; // Referência ao jogador (se estiver sobre a plataforma)

    void Start()
    {
        alvo = pontoB.position;           // Começa indo em direção ao ponto B
        ultimaPosicao = transform.position; // Guarda posição inicial
    }

    void Update()
    {
        // Move a plataforma em direção ao ponto de destino
        transform.position = Vector3.MoveTowards(transform.position, alvo, velocidade * Time.deltaTime);

        // Calcula o deslocamento (diferença entre posição atual e anterior)
        deslocamento = transform.position - ultimaPosicao;

        // Atualiza a posição anterior
        ultimaPosicao = transform.position;

        // Se o jogador está sobre a plataforma, move junto com ela
        if (jogadorEmCima != null)
        {
            jogadorEmCima.transform.position += deslocamento;
        }

        // Quando chega ao destino, inverte o alvo
        if (Vector3.Distance(transform.position, alvo) < 0.1f)
        {
            alvo = (alvo == pontoA.position) ? pontoB.position : pontoA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se o jogador colidir por cima da plataforma, "gruda" nela logicamente
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica se o jogador está realmente sobre a plataforma (não colidindo de lado)
            if (collision.contacts[0].normal.y < 0f)
            {
                jogadorEmCima = collision.gameObject;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Quando o jogador sai da plataforma, para de mover junto
        if (collision.gameObject == jogadorEmCima)
        {
            jogadorEmCima = null;
        }
    }
}
