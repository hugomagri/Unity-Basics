using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidade = 0.6f;

    public float variacaoY;

    private void Awake()
    {
        transform.Translate(Vector3.up * Random.Range(-variacaoY,variacaoY));
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision){
         Destruir();
    }

    public void Destruir(){
       Destroy(gameObject);
     }
}