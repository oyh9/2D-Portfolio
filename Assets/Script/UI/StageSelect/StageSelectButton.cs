using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    public string stageID;
    public Color clearedColor = Color.gray;
    public Color defaultColor = Color.white;

    private void Start()
    {
        Button button = GetComponent<Button>();
        Image image = GetComponent<Image>();

        // PlayerPrefs에서 클리어 여부 확인
        bool isCleared = PlayerPrefs.GetInt("StageClear_" + stageID, 0) == 1;

        // 색상 적용
        if (image != null)
        {
            image.color = isCleared ? clearedColor : defaultColor;
        }
    }
}
