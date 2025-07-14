using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SaveManager.Instance.SetCheckpoint(transform.position);
            Debug.Log("세이브 포인트 체크 : " + transform.position);
        }
    }
}
