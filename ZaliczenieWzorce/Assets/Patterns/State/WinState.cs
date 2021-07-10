using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    public void OnEnter()
    {
        PanelManager.Instance.ShowPanel(PanelType.Win);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}
