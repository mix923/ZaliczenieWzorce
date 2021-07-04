using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RotaryHeart.Lib.SerializableDictionary;
using DG.Tweening;

public enum PanelType { Menu, Game, GameOver, Win }

public class PanelManager : Singleton<PanelManager>
{
    public PanelDictionary panelDictionary;

    public void ShowPanel(PanelType panel)
    {
        foreach(KeyValuePair<PanelType, RectTransform> item in panelDictionary)
        {
            if(item.Key.Equals(panel) == false)
            {
                panelDictionary[item.Key].DOAnchorPos(item.Value.GetComponent<Panel>().HideValue, 1f);
            }
        }

        panelDictionary[panel].DOAnchorPos(Vector2.zero, 1f).SetDelay(1f);
    }


    [System.Serializable]
    public class PanelDictionary : SerializableDictionaryBase<PanelType, RectTransform> { }
}
