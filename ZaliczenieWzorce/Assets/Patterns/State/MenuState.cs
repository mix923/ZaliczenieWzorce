using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : State
{
    public void OnEnter()
    {
        PanelManager.Instance.ShowPanel(PanelType.Menu);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}
