using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private int currentScore = 0;
    private int maxScore;

    private void OnEnable()
    {
        EventManager.Instance.OnClickCorrectAnswer.AddListener(UpdateText);
        EventManager.Instance.OnGenerateNewLevel.AddListener(ResetScoreText);
    }

    private void UpdateText()
    {
        currentScore++;
        text.text = $"Score: {currentScore}/{maxScore}";
    }

    private void ResetScoreText(int score, Color color)
    {
        currentScore = 0;
        maxScore = score;
        text.text = $"Score: {currentScore}/{maxScore}";
    }

    private void OnDisable()
    {
        EventManager.Instance.OnClickCorrectAnswer.RemoveListener(UpdateText);
        EventManager.Instance.OnGenerateNewLevel.RemoveListener(ResetScoreText);
    }
}
