using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float dano = 10f; // Dano que o projétil causa
    public float tempoDeVida = 3f; // Tempo antes de ser destruído automaticamente

    void Start()
    {
        // Destroi o projétil após o tempo definido para evitar acúmulo na cena
        Destroy(gameObject, tempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        // Se o projétil colidir com um inimigo...
        if (colisao.CompareTag("Inimigo"))
        {
            // Aplica dano ao inimigo, caso ele tenha o script Vida
            colisao.GetComponent<Vida>()?.ReceberDano(dano);

            // Destroi o projétil após o impacto
            Destroy(gameObject);
        }
    }
}
