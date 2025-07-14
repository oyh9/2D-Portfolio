using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private Vector2 checkpointPos;
    private Vector2 defaultSpawnPoint;
    private bool hasCheckpoint = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 spawnPos = SaveManager.Instance.HasCheckpoint()
       ? SaveManager.Instance.GetCheckpoint()
       : defaultSpawnPoint;

        transform.position = spawnPos;
    }

    public void SetCheckpoint(Vector2 position)
    {
        checkpointPos = position;
        hasCheckpoint = true;
    }

    public Vector2 GetCheckpoint()
    {
        return checkpointPos;
    }

    public bool HasCheckpoint()
    {
        return hasCheckpoint;
    }

    public void ResetCheckpoint()
    {
        hasCheckpoint = false;
    }

    public void Respawn()
    {
        transform.position = SaveManager.Instance.HasCheckpoint()
            ? SaveManager.Instance.GetCheckpoint()
            : defaultSpawnPoint;
    }
}
