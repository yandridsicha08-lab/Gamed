using UnityEngine;
using TMPro;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;         
    public Vector2 spawnRange = new Vector2(6f, 3f);
    public int killsPerSpawn = 5;          
    public int maxEnemies = 5;    
    public Stats playerStats;

    private int currentKills = 0;
    private int currentEnemies = 1;
    public int comboCounter = 1;      
    public int maxCombo = 10;          
    public TMP_Text comboText;
    public float maxShakeAmount = 20f;  
    private Vector3 comboOriginalPos; 
    public CameraShake cameraShake;

    void Start()
    {
        if (comboText != null)
        {
            comboOriginalPos = comboText.rectTransform.localPosition;
        } 
    }
    
    void Update()
    {
        if (comboText != null && comboCounter > 1)
        {
            
            float minShake = 2f;  
            float maxShake = maxShakeAmount; 

            
            float t = (comboCounter - 2) / (float)(maxCombo - 2);

            
            float intensity = Mathf.Lerp(minShake, maxShake, t);

            float xOffset = Random.Range(-intensity, intensity);
            float yOffset = Random.Range(-intensity, intensity);

            comboText.rectTransform.localPosition = comboOriginalPos + new Vector3(xOffset, yOffset, 0);
        }
        else if (comboText != null)
        {
            comboText.rectTransform.localPosition = comboOriginalPos;
        }
    }

    public void EnemyKilled()
    {
        currentKills++;

      
        if (currentKills % 5 == 0)
        {
            comboCounter = Mathf.Min(comboCounter + 1, maxCombo);
            UpdateComboUI(); 
        }

       
        if (currentKills % 5 == 0)
        {
            playerStats.health = Mathf.Min(playerStats.health + 1, 5); 
            playerStats.UpdateUi();
        }

        
        if (currentEnemies < maxEnemies && currentKills % killsPerSpawn == 0)
        {
            SpawnEnemy();
            currentEnemies++;
        }
        
        if (currentKills % 5 == 0)
        {
            comboCounter = Mathf.Min(comboCounter + 1, maxCombo);
            UpdateComboUI();

           
            if (comboText != null)
                StartCoroutine(ShakeComboText());
        }
        
        if (cameraShake != null)
        {
            cameraShake.Shake(0.1f, 0.05f); // 0.1s duration, 0.05 units magnitude
        }
        
        playerStats.AddScore(1 * comboCounter);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(
            Random.Range(-spawnRange.x, spawnRange.x),
            Random.Range(-spawnRange.y, spawnRange.y)
        );

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
    void UpdateComboUI()
    {
        if (comboText != null)
        {
            comboText.text = "Combo: x" + comboCounter;

            
            Color startColor = Color.white;               
            Color endColor = new Color(0.5f, 0, 0);      
            float t = (comboCounter - 1) / (float)(maxCombo - 1);  
            comboText.color = Color.Lerp(startColor, endColor, t);
        }
    }
    IEnumerator ShakeComboText()
    {
        if (comboText == null) yield break;

        float duration = 0.5f; 
        float elapsed = 0f;

      
        float intensity = (comboCounter / (float)maxCombo) * maxShakeAmount;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float xOffset = Random.Range(-intensity, intensity);
            float yOffset = Random.Range(-intensity, intensity);

            comboText.rectTransform.localPosition = comboOriginalPos + new Vector3(xOffset, yOffset, 0);

            yield return null;
        }

        
        comboText.rectTransform.localPosition = comboOriginalPos;
    }
}
