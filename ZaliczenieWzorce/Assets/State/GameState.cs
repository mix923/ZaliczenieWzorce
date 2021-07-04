using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    private Level currentLevel;

    public void OnEnter()
    {
        PanelManager.Instance.ShowPanel(PanelType.Game);
        LevelGenerator.Instance.GenerateLevel();
        currentLevel = Resources.FindObjectsOfTypeAll<Level>()[0];
    }

    public void OnUpdate()
    {
        if(currentLevel.NumberOfButtonsToGuess == 0)
        {
            EventManager.Instance.OnCompleteLevel?.Invoke();
        }
    }

    public void OnExit()
    {

    }
}
