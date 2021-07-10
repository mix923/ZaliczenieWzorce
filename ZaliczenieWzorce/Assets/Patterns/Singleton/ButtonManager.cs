using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : Singleton<ButtonManager>
{
    public void OnClickButtonPlay()
    {
        GameManager.Instance.ChangeState(new GameState());
    }

    public void OnClickButtonMenu()
    {
        GameManager.Instance.ChangeState(new MenuState());
    }

    public void OnClickButtonExit()
    {
        
    }

    public void OnClickButtonShare()
    {
        
    }
}
