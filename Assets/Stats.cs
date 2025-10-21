using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int health = 5;
    public int score = 0;
    public GameObject gameOverPanel;

    public TMP_Text healthText;
    public TMP_Text scoreText;
    private SpriteRenderer spriteRenderer;

    public PlayerColor playerColor;
    public bool isInvincible = false;

    private Movement movement;  
    private float defaultSpeed;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();

        if (movement != null)
        {
            defaultSpeed = movement.speed; 
        }

        UpdateUi();
    }

    public IEnumerator invincibleCoroutine(float duration)
    {
        isInvincible = true;
        spriteRenderer.color = Color.cyan; 
        yield return new WaitForSeconds(duration);

        isInvincible = false;
        spriteRenderer.color = Color.white; 

        if (movement != null)
        {
            movement.speed = defaultSpeed;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        health -= amount;
        if (health <= 0)
        {
            health = 0;
            UpdateUi();
            GameOver(); 
            return;
        }

        UpdateUi();
        playerColor.Flash();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUi();
    }

    public void UpdateUi()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            StartCoroutine(FadeInGameOver());
        }

        Time.timeScale = 0f;
    }

    IEnumerator FadeInGameOver()
    {
        Image panelImage = gameOverPanel.GetComponent<Image>();
        TextMeshProUGUI gameOverText = gameOverPanel.GetComponentInChildren<TextMeshProUGUI>();

        float duration = 1f;
        float elapsed = 0f;

        
        Color textColor = gameOverText.color;
        textColor.a = 0;
        gameOverText.color = textColor;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            float alpha = Mathf.Clamp01(elapsed / duration);

            
            Color panelColor = panelImage.color;
            panelColor.a = alpha;
            panelImage.color = panelColor;

            
            textColor.a = alpha;
            gameOverText.color = textColor;

            yield return null;
        }
    }
}