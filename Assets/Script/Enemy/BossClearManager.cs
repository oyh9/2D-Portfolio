using UnityEngine;
using UnityEngine.SceneManagement;

public class BossClearManager : MonoBehaviour
{
    private void OnEnable() //보스 클리어시 활성화
    {
        //BossTest.OnBossDefeated += HandleBossDefeated; 
    }

    private void OnDisable() //보스 미클리어시 비활성화
    {
        //BossTest.OnBossDefeated -= HandleBossDefeated;
    }

    private void HandleBossDefeated()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("StageClear_" + currentScene, 1);
        PlayerPrefs.Save();

        Debug.Log("Stage Cleared! Saved to PlayerPrefs.");

        // 예시: 허브 씬으로 이동
        SceneManager.LoadScene("Main");
    }
}
