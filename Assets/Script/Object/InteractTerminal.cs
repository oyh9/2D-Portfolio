using UnityEngine;

public class InteractTerminal : MonoBehaviour
{
    private bool playerInRange = false;
    public GameObject stageSelectUI;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            stageSelectUI.SetActive(true);
            Time.timeScale = 0f; // 게임 일시정지
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
