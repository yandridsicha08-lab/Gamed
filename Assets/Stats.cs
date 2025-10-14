using UnityEngine;
using TMPro;
using System.Collections;

public class Stats : MonoBehaviour
{
    public int health = 5;
    public int score = 0;

    public TMP_Text healthText;
    public TMP_Text scoreText;
    private SpriteRenderer spriteRenderer;
    
    public PlayerColor  playerColor;
    public bool isInvincible = false;

    public IEnumerator invincibleCoroutine (float duration)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isInvincible = true;
        spriteRenderer.color = Color.cyan;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
        spriteRenderer.color = Color.white;
    }
    

    void Start()
    {
        UpdateUi();
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;
        health -= amount;
        if (health < 0) 
        {
            health = 0;
        }
        UpdateUi();
        playerColor.Flash();
    }

    public void AddScore(int amount)
    {
       score +=  amount;
       UpdateUi();
    }

    void UpdateUi()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }



}
