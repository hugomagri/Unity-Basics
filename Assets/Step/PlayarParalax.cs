using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour
{
    public float velocidade = 0.6f;
    private Vector3 posicaoInicial;
    private float tamanhoDaImagem;

    void Awake()
    {
        posicaoInicial = transform.position;
        float tamanhoDaImagemReal = GetComponent<SpriteRenderer>().size.x;
        float escala = transform.localScale.x;
        tamanhoDaImagem = tamanhoDaImagemReal * escala;
    }

    void Update()
    {
        float deslocamento = Mathf.Repeat(velocidade * Time.time, tamanhoDaImagem);
        transform.position = posicaoInicial + Vector3.left * deslocamento;

    }
}