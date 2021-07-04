using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textColor;

    private void OnEnable()
    {
        EventManager.Instance.OnGenerateNewLevel.AddListener(SetUpColorText);
    }

    private void SetUpColorText(int score, Color color)
    {
        textColor.text =  $"Tap <color={ToRGBHex(color)}>this</color>\nobjects";
    }

    private void OnDisable()
    {
        EventManager.Instance.OnGenerateNewLevel.RemoveListener(SetUpColorText);
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
