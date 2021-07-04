using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;

public class TitleInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Level level;
    [SerializeField]
    private bool scoreText;
    [SerializeField]
    private bool levelText;
    [SerializeField]
    private bool scoreTextGameOver;

    private void Update()
    {
        if(scoreText)
        {
            text.text = $"Your score: {level.LevelIndex}";
        }
        else if(levelText)
        {
            text.text = $"Tap <color={ToRGBHex(level.CorrectColor)}>this</color>\nobjects";
        }
        else if(scoreTextGameOver)
        {
            text.text = $"<color=red>Game Over</color><size=60%>\nYour score: {level.LevelIndex}</size>";
        }
    }

    private string ToRGBHex(Color c)
    {
        return string.Format("#{0:X2}{1:X2}{2:X2}", ToByte(c.r), ToByte(c.g), ToByte(c.b));
    }

    private byte ToByte(float f)
    {
        f = Mathf.Clamp01(f);
        return (byte)(f * 255);
    }
}
