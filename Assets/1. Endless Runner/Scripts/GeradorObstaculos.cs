using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
     public GameObject modeloObstaculo;

    public float tempoParaGerar = 3;
    private float cronometro;


    private void Awake()
    {
        cronometro = tempoParaGerar;
    }

    // Update is called once per frame
    void Update()
    {
        cronometro -= Time.deltaTime;
        if(cronometro < 0)
        {
            GameObject.Instantiate(modeloObstaculo, transform.position, Quaternion.identity);
            cronometro = tempoParaGerar;
        }
        
    }
}