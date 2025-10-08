using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que entrou no gatilho é o jogador
        if (collision.CompareTag("Player"))
        {
            // Obtém o script de controle do jogador
            PlayerRespawn player = collision.GetComponent<PlayerRespawn>();

            // Se o jogador tiver o script, define este ponto como o novo checkpoint
            if (player != null)
            {
                player.DefinirCheckpoint(transform.position);
                Debug.Log("Checkpoint atualizado para: " + transform.position);
            }
        }
    }
}
