using UnityEngine;

public class Enemy : MonoBehaviour
{
   private GameManager gameManager;

   void Start()
   {
      gameManager = FindObjectOfType<GameManager>(); // get reference to GameManager
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      Stats stats = collision.gameObject.GetComponent<Stats>();
      if (stats != null)
      {
         if (stats.isInvincible)
         {
            stats.AddScore(1);

            // Tell GameManager this enemy was killed
            if (gameManager != null)
               gameManager.EnemyKilled();

            // Respawn enemy instantly
            GetComponent<EnemyRespawn>().RespawnInstantly();
         }
         else
         {
            stats.TakeDamage(1);
         }
      }
   }
}
