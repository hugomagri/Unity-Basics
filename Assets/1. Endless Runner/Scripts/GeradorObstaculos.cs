using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    public GameObject modeloObstaculo;  // O modelo do obstáculo a ser gerado
    public float tempoParaGerar = 3f;   // Tempo entre as gerações
    public int quantidadeMaxima = 5;    // Quantidade máxima de objetos a serem gerados
    public bool esperarAntesDeGerar = true; // Se verdadeiro, espera antes de gerar, se falso, gera e depois espera

    private float cronometro;           // Cronômetro que controla o tempo
    private int objetosGerados = 0;     // Contador de objetos gerados

    private void Awake()
    {
        cronometro = tempoParaGerar;   // Inicializa o cronômetro
    }

    void Update()
    {
        if (objetosGerados >= quantidadeMaxima)
        {
            return; // Não gera mais objetos se atingir o limite
        }

        if (esperarAntesDeGerar)
        {
            // Se espera antes de gerar, espera o tempo e gera depois
            cronometro -= Time.deltaTime;
            if (cronometro <= 0)
            {
                GerarObstaculo();
                cronometro = tempoParaGerar;  // Reseta o cronômetro após gerar
            }
        }
        else
        {
            // Se gera primeiro e depois espera
            GerarObstaculo();
            cronometro = tempoParaGerar;  // Reseta o cronômetro após gerar
            esperarAntesDeGerar = true;  // Se gerou, agora espera até o próximo ciclo
        }
    }

    // Função para gerar o obstáculo
    void GerarObstaculo()
    {
        Instantiate(modeloObstaculo, transform.position, Quaternion.identity);  // Gera o objeto
        objetosGerados++;  // Incrementa o contador de objetos gerados
    }
}
