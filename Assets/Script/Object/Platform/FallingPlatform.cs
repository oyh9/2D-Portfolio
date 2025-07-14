using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float disappearDelay = 0.5f;
    public float reappearDelay = 3f;

    private Collider2D col;
    private SpriteRenderer sr;

    private bool isFading = false;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFading && collision.collider.CompareTag("Player"))
        {
            StartCoroutine(DisappearAndReappear());
        }
    }

    private IEnumerator DisappearAndReappear()
    {
        isFading = true;

        yield return new WaitForSeconds(disappearDelay);

        // 사라짐
        col.enabled = false;
        sr.enabled = false;

        yield return new WaitForSeconds(reappearDelay);

        // 다시 나타남
        col.enabled = true;
        sr.enabled = true;
        isFading = false;
    }
}
