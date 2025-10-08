using UnityEngine;

public class ItemInventario : MonoBehaviour
{
    public string nomeItem = "Moeda";
    public int quantidade = 1;
    public Inventario Inventario; // Referência ao inventário do jogador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Adiciona ao inventário
            Inventario.AdicionarItem(nomeItem, quantidade);

            // Remove o item da cena
            Destroy(gameObject);
        }
    }
}
