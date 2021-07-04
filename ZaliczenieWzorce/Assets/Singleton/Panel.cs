using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [field: SerializeField]
    public Vector2 HideValue { get; set; }

    private void Start()
    {
        HideValue = new Vector2(HideValue.x * GetComponent<RectTransform>().rect.width , HideValue.y * GetComponent<RectTransform>().rect.height);
        GetComponent<RectTransform>().anchoredPosition = HideValue;
    }

    
}
