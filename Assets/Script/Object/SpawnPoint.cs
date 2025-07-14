using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        /*if(GameObject.FindGameObjectsWithTag("Player") == null)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }*/

        Debug.Log("PlayerSpawner 시작됨");

        if (playerPrefab == null)
        {
            Debug.LogError("playerPrefab이 연결되지 않았습니다!");
            return;
        }

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
            Debug.Log("플레이어 생성됨");
        }
        else
        {
            Debug.Log("씬에 이미 플레이어가 존재합니다.");
        }
    }
}
