using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnswer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Sprite squareSprite;
    [SerializeField]
    private Sprite circleSprite;

    private Level currentLevel;
    private bool isCorrect;
    private Animation typeAnimation;


    public void Initialize(Animation globalAnimation, Level leveldata, bool correct, Button button)
    {
        typeAnimation = globalAnimation;
        currentLevel = leveldata;
        isCorrect = correct;

        if(button.GetImage().Equals("Square"))
        {
            GetComponent<Image>().sprite = squareSprite;
        }
        else if(button.GetImage().Equals("Circle"))
        {
            GetComponent<Image>().sprite = circleSprite;
        }
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
