using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class VidaComVulnerabilidade : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public float vidaMaxima = 100f; // Vida total
    private float vidaAtual;        // Vida atual

    [Header("Feedback de Dano")]
    public float duracaoPiscar = 0.15f;    // Tempo de cada piscada
    public int quantidadePiscos = 4;       // Quantas vezes pisca
    public float forcaRecuo = 5f;          // Força do knockback horizontal
    public float tempoInvulneravel = 1f;   // Tempo de invencibilidade após dano
    public float duracaoKnockback = 0.2f;  // Quanto tempo dura o knockback

    private bool invulneravel = false;     // Flag de invulnerabilidade
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()
    {
        vidaAtual = vidaMaxima;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Método chamado para aplicar dano
    public void ReceberDano(float dano, Vector2 origemDano)
    {
        if (invulneravel) return; // Ignora se estiver invulnerável

        vidaAtual -= dano;
        Debug.Log($"{gameObject.name} recebeu {dano} de dano. Vida restante: {vidaAtual}");

        // Inicia piscar
        StartCoroutine(Piscar());

        // Aplica knockback horizontal
        StartCoroutine(Knockback(origemDano));

        // Invulnerabilidade temporária
        StartCoroutine(TornarInvulneravel());

        if (vidaAtual <= 0)
            Morrer();
    }

    // Coroutine para piscar o sprite
    private IEnumerator Piscar()
    {
        for (int i = 0; i < quantidadePiscos; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(duracaoPiscar);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(duracaoPiscar);
        }
    }

    // Coroutine para aplicar knockback horizontal
    private IEnumerator Knockback(Vector2 origemDano)
    {
        // Desativa script de movimento do inimigo se houver
        InimigoIA ia = GetComponent<InimigoIA>();
        if (ia != null) ia.enabled = false;

        // Calcula direção horizontal oposta à origem do dano
        Vector2 direcao = ((Vector2)transform.position - origemDano).normalized;

        float tempoDecorrido = 0f;
        while (tempoDecorrido < duracaoKnockback)
        {
            // Aplica velocidade horizontal somente (mantém Y atual)
            rb.linearVelocity = new Vector2(direcao.x * forcaRecuo, 3f);
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }

        // Reseta velocidade horizontal após knockback
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        // Reativa script de movimento do inimigo
        if (ia != null) ia.enabled = true;
    }

    // Coroutine para invulnerabilidade
    private IEnumerator TornarInvulneravel()
    {
        invulneravel = true;
        yield return new WaitForSeconds(tempoInvulneravel);
        invulneravel = false;
    }

    // Método de morte
    private void Morrer()
    {
        Debug.Log($"{gameObject.name} morreu!");
        Destroy(gameObject);
    }
}
