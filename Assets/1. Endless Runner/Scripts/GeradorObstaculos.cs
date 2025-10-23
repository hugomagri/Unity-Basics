using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    public GameObject modeloObstaculo;  // O modelo do obst�culo a ser gerado
    public float tempoParaGerar = 3f;   // Tempo entre as gera��es
    public int quantidadeMaxima = 5;    // Quantidade m�xima de objetos a serem gerados
    public bool esperarAntesDeGerar = true; // Se verdadeiro, espera antes de gerar, se falso, gera e depois espera

    private float cronometro;           // Cron�metro que controla o tempo
    private int objetosGerados = 0;     // Contador de objetos gerados

    private void Awake()
    {
        cronometro = tempoParaGerar;   // Inicializa o cron�metro
    }

    void Update()
    {
        if (objetosGerados >= quantidadeMaxima)
        {
            return; // N�o gera mais objetos se atingir o limite
        }

        if (esperarAntesDeGerar)
        {
            // Se espera antes de gerar, espera o tempo e gera depois
            cronometro -= Time.deltaTime;
            if (cronometro <= 0)
            {
                GerarObstaculo();
                cronometro = tempoParaGerar;  // Reseta o cron�metro ap�s gerar
            }
        }
        else
        {
            // Se gera primeiro e depois espera
            GerarObstaculo();
            cronometro = tempoParaGerar;  // Reseta o cron�metro ap�s gerar
            esperarAntesDeGerar = true;  // Se gerou, agora espera at� o pr�ximo ciclo
        }
    }

    // Fun��o para gerar o obst�culo
    void GerarObstaculo()
    {
        Instantiate(modeloObstaculo, transform.position, Quaternion.identity);  // Gera o objeto
        objetosGerados++;  // Incrementa o contador de objetos gerados
    }
}
