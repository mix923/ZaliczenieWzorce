using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class Animation
{
    public abstract void HideEffect(Transform transform);
}

public class ScaleAnimation : Animation
{
    public override void HideEffect(Transform transform)
    {
        transform.GetComponent<RectTransform>().DOScale(Vector3.zero, 1f);
    }
}

public class FadeAnimation : Animation
{
    public override void HideEffect(Transform transform)
    {
        transform.GetComponent<Image>().DOFade(0, 1f);
    }
}

public class SpecialAnimation : Animation
{
    public override void HideEffect(Transform transform)
    {
        transform.GetComponent<RectTransform>().DORotate(new Vector3(0,0, 90), 1f);
        transform.GetComponent<RectTransform>().DOScale(Vector3.zero, 1f);
    }
}
