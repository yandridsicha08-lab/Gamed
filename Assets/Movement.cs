using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public Stats stats;
    public float speed = 1f;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (transform.position.x > 9)
        {
            transform.position = new Vector2(-7f, transform.position.y);
            stats.AddScore(1);
            stats.StartCoroutine(stats.invincibleCoroutine(3f));
        }

        if (transform.position.x < -9)
        {
            transform.position = new Vector2(7f, transform.position.y);
            stats.AddScore(1);
            stats.StartCoroutine(stats.invincibleCoroutine(3f));
        }

        if (transform.position.y > 5)
        {
            transform.position = new Vector2(transform.position.x, -3);
            stats.AddScore(1);
            stats.StartCoroutine(stats.invincibleCoroutine(3f));
        }

        if (transform.position.y < -5)
        {
            transform.position = new Vector2(transform.position.x, 3);
            stats.AddScore(1);
            stats.StartCoroutine(stats.invincibleCoroutine(3f));
        }
        

    }
    
}
