using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 ultimoCheckpoint;

    void Start()
    {
        ultimoCheckpoint = transform.position;
    }

    public void DefinirCheckpoint(Vector2 pos)
    {
        ultimoCheckpoint = pos;
    }

    public void Morrer()
    {
        transform.position = ultimoCheckpoint;
        Debug.Log("🔁 Jogador voltou ao último checkpoint!");
    }
}
