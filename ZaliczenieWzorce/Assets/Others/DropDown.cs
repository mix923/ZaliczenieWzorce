using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    [SerializeField]
    private Dropdown dropdown;
    [SerializeField]
    private Level level;

    public void OnChange()
    {
        if(dropdown.value == 0)
        {
            level.FactoryButton = new FactorySquareButton();
        }
        else if(dropdown.value == 1)
        {
            level.FactoryButton = new FactoryCircleButton();
        }
    }
}
