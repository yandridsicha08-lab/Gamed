using UnityEngine;

public class Enemy : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      Stats stats = collision.gameObject.GetComponent<Stats>();
      if (stats != null)
      {
         if (stats.isInvincible)
         {
            stats.AddScore(1);
            Destroy(gameObject);
         }
         else
         {
            stats.TakeDamage(1);
         }
      }
   }
    
}
