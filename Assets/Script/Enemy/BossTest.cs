using UnityEngine;

public class BossTest : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    public delegate void BossDeathDelegate();
    public static event BossDeathDelegate OnBossDefeated;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss died!");

        // 이벤트 호출 (클리어 로직에 알림)
        OnBossDefeated?.Invoke();

        // 죽는 연출 등 추가 가능
        Destroy(gameObject);
    }
}
