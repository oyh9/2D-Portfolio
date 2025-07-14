using UnityEngine;

public class StageSelectController : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseStageSelectUI();
        }
    }

    public void CloseStageSelectUI()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
