using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private Dictionary<string, int> itens = new Dictionary<string, int>();

    public void AdicionarItem(string nome, int quantidade = 1)
    {
        if (itens.ContainsKey(nome))
            itens[nome] += quantidade;
        else
            itens[nome] = quantidade;

        Debug.Log($"Adicionado {quantidade}x {nome}. Total: {itens[nome]}");
    }

    public void RemoverItem(string nome, int quantidade = 1)
    {
        if (itens.ContainsKey(nome))
        {
            itens[nome] -= quantidade;
            if (itens[nome] <= 0) itens.Remove(nome);
        }
    }

    public int ConsultarItem(string nome)
    {
        return itens.ContainsKey(nome) ? itens[nome] : 0;
    }
}
