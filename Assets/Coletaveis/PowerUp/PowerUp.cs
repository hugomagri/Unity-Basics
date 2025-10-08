using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public float duracao = 3f; // Duração do efeito

    void OnTriggerEnter2D(Collider2D jogador)
    {
        if (jogador.CompareTag("Player"))
        {
            StartCoroutine(AplicarPowerUp(jogador)); // Inicia a coroutine para aplicar o power-up
            
        }
    }

    private IEnumerator AplicarPowerUp(Collider2D jogador)
    {
         // Pega o SpriteRenderer do jogador para mudar a cor
            var sprite = jogador.GetComponent<SpriteRenderer>();
            Color corOriginal = sprite.color;  // salva a cor original
        // Exemplo: aumenta velocidade do jogador
        var movimento = jogador.GetComponent<PlayerBasico>();
        if (movimento != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false; // Esconde o power-up
            gameObject.GetComponent<Collider2D>().enabled = false; // Desativa o collider

            movimento.velocidade *= 2f;
            // Muda a cor do jogador enquanto o power-up estiver ativo
            sprite.color = Color.yellow; //amarelo
            yield return new WaitForSeconds(duracao);
            movimento.velocidade /= 2f;
            // Retorna a cor original
            sprite.color = corOriginal;

            Destroy(gameObject); // Destrói o power-up após ser coletado
        }
    }
}
