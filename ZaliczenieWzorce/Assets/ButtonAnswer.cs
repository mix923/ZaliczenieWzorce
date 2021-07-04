using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnswer : MonoBehaviour, IPointerClickHandler
{
    private Level currentLevel;
    private bool isCorrect;
    private Animation typeAnimation;


    public void Initialize(Animation globalAnimation, Level leveldata, bool correct)
    {
        typeAnimation = globalAnimation;
        currentLevel = leveldata;
        isCorrect = correct;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isCorrect)
        {
            EventManager.Instance.OnClickCorrectAnswer?.Invoke();
            ShowHideEffectAndDestroy();
        }
        else
        {
            EventManager.Instance.OnGameOverLevel?.Invoke();
        }
    }


    public void ShowHideEffectAndDestroy()
    {
        StartCoroutine(Wait());
        typeAnimation.HideEffect(this.transform);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        currentLevel.NumberOfButtonsToGuess--;
    }
}
