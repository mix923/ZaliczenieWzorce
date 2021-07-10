using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private int currentLevel = 0;

    private void OnEnable()
    {
        EventManager.Instance.OnGenerateNewLevel.AddListener(UpdateText);
        EventManager.Instance.OnGameOverLevel.AddListener(ResetLevel);
    }

    private void UpdateText(int score, Color color)
    {
        currentLevel++;
        text.text = $"Level: {currentLevel}";
    }

    private void ResetLevel()
    {
        currentLevel = 0;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGenerateNewLevel.RemoveListener(UpdateText);
        EventManager.Instance.OnGameOverLevel.RemoveListener(ResetLevel);
    }
}
