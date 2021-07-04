using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private State currentState;

    private void OnEnable()
    {
        EventManager.Instance.OnCompleteLevel.AddListener(ChangeStateToWin);
        EventManager.Instance.OnGameOverLevel.AddListener(ChangeStateToGameOver);
    }

    private void Start()
    {
        StartCoroutine(Wait(1f));
    }

    private void Update()
    {
        currentState?.OnUpdate();
    }

    public void ChangeState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;

        currentState.OnEnter();
    }

    private void ChangeStateToGameOver()
    {
        ChangeState(new GameOverState());
    }

    private void ChangeStateToWin()
    {
        ChangeState(new WinState());
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        ChangeState(new MenuState());
    }

    private void OnDisable()
    {
        EventManager.Instance.OnCompleteLevel.RemoveListener(ChangeStateToWin);
        EventManager.Instance.OnGameOverLevel.RemoveListener(ChangeStateToGameOver);
    }
}
