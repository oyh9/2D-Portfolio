using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    [Tooltip("메인 씬 이름 (예: MainMenu, StageSelect 등)")]
    public string returnToSceneName = "Main";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        string currentSceneName = SceneManager.GetActiveScene().name;

        // 스테이지 클리어 상태 저장
        SetStageClear(currentSceneName);

        // 디버그 출력
        Debug.Log($"Stage '{currentSceneName}' cleared!");

        // 메인 씬으로 이동
        SceneManager.LoadScene(returnToSceneName);
    }

    private void SetStageClear(string stageName)
    {
        string key = $"StageClear_{stageName}";

        if (PlayerPrefs.GetInt(key, 0) == 0)
        {
            PlayerPrefs.SetInt(key, 1);
            PlayerPrefs.Save();
        }
    }
}
