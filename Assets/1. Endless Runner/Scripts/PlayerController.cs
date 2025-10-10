using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float velocidade = 3;
    private Vector3 posicaoInicial;
    Rigidbody2D rb;
    
    //método Awake é chamado toda vez que o objeto é criado
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           Impulsionar();
        }
    }
    private void Impulsionar()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * velocidade, ForceMode2D.Impulse);
    }
}