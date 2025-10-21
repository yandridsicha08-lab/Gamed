using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    
    public Vector2 spawnRange = new Vector2(5f, 2f);
    
    public void RespawnInstantly()
    {
        
        transform.position = new Vector2(
            Random.Range(-spawnRange.x, spawnRange.x),
            Random.Range(-spawnRange.y, spawnRange.y)
        );
        
        gameObject.SetActive(true);
    }
}
