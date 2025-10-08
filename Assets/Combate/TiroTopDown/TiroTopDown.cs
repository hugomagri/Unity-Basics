using UnityEngine;

public class TiroTopDown : MonoBehaviour
{
    [Header("Configurações do Tiro")]
    public GameObject prefabProjetil; // Prefab do projétil que será instanciado ao atirar
    public float velocidadeProjetil = 10f; // Velocidade do projétil
    public float tempoEntreTiros = 0.3f;   // Tempo mínimo entre tiros consecutivos

    public Transform pontoTiro; // Ponto de onde o projétil será disparado

    private float tempoProximoTiro = 0f; // Guarda o tempo em que o jogador pode atirar novamente

    void Update()
    {
        // Rotaciona o jogador para olhar na direção do mouse
        GirarParaMouse();

        // Verifica se o botão esquerdo do mouse foi pressionado e se já passou o tempo de cooldown
        if (Input.GetMouseButton(0) && Time.time >= tempoProximoTiro)
        {
            Atirar(); // Instancia o projétil
            tempoProximoTiro = Time.time + tempoEntreTiros; // Atualiza o tempo do próximo tiro permitido
        }
    }

    // Método que gira o jogador na direção do mouse
    void GirarParaMouse()
    {
        // Pega a posição do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Z sempre 0 no 2D

        // Calcula a direção do jogador para o mouse
        Vector3 direcao = (mousePos - transform.position).normalized;

        // Calcula o ângulo em graus usando Atan2 (y,x)
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

        // Aplica a rotação no eixo Z
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    // Método que instancia o projétil e define sua direção e velocidade
    void Atirar()
    {
        // Instancia o prefab do projétil na posição do ponto de tiro
        GameObject proj = Instantiate(prefabProjetil, pontoTiro.position, Quaternion.identity);

        // Calcula a direção do projétil em direção ao mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direcao = (mousePos - proj.transform.position).normalized;

        // Aplica velocidade ao Rigidbody2D do projétil
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direcao * velocidadeProjetil;
    }
}
