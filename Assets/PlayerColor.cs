using UnityEngine;
using System.Collections;
public class PlayerColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    public void Flash()
    {
        StartCoroutine(FlashRed());
    }
    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }
}
