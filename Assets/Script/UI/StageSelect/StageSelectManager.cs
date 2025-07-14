using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public void SelectStage(string stageSceneName)
    {
        PlayerPrefs.SetString("SelectedStage", stageSceneName);
        Time.timeScale = 1f;
        SceneManager.LoadScene(stageSceneName);
    }
}
