using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private Vector2 defaultSpawnPos;
    private Animator animator;
    private Rigidbody2D rb;
    private Collider2D col;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        defaultSpawnPos = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetBool("IsDead", true);

        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static; // 움직이지 않게

        GetComponent<PlayerController>().enabled = false;
        col.enabled = false;

        StartCoroutine(RespawnAfterDelay(1f)); // 2초 후 리스폰
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 위치 이동
        transform.position = SaveManager.Instance.HasCheckpoint()
            ? SaveManager.Instance.GetCheckpoint()
            : defaultSpawnPos;

        col.enabled = false; //콜라이더 제거

        animator.SetBool("IsDead", false);
        animator.Play("Idle");

        // 잠깐 대기
        yield return new WaitForSeconds(0.05f);

        // 상태 초기화
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = Vector2.zero;

        GetComponent<PlayerController>().enabled = true;
        col.enabled = true;

        currentHealth = maxHealth;
        isDead = false;
    }
}
