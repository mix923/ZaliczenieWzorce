using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : State
{
    public void OnEnter()
    {
        PanelManager.Instance.ShowPanel(PanelType.GameOver);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        LevelGenerator.Instance.ResetGenerator();
    }
}
