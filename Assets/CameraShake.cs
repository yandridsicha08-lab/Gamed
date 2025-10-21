using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void Shake(float duration = 0.2f, float magnitude = 0.9f)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float xOffset = Random.Range(-magnitude, magnitude);
            float yOffset = Random.Range(-magnitude, magnitude);

            transform.localPosition = originalPos + new Vector3(xOffset, yOffset, 0);

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}