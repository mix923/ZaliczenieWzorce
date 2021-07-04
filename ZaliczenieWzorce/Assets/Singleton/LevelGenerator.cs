using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : Singleton<LevelGenerator>
{
    [SerializeField]
    private Level levelData;
    [SerializeField]
    private RectTransform panelButtons;
    [SerializeField]
    private GameObject buttonPrefab;
    private List<Color> colors = new List<Color>();
    private Animation currentAniamtion; 

    private void Awake()
    {
        ResetGenerator();
    }

    public void ResetGenerator()
    {
        levelData.LevelIndex = 0;
        panelButtons.localScale = Vector3.one;
    }

    public void GenerateLevel()
    {
        ClearPreviousData();
        SetUpAnimation();
        panelButtons.localScale *= 0.9f;
        levelData.LevelIndex += 1;
        levelData.NumberOfButtonsToGuess = levelData.LevelIndex + 1;
        panelButtons.sizeDelta = new Vector2((levelData.LevelIndex + 1) * 200, (levelData.LevelIndex + 1) * 200);
        levelData.CorrectColor = GenerateColor();

        List<int> items = Enumerable.Range(0, (int)Mathf.Pow(levelData.LevelIndex + 1, 2)).ToList();
        List<int> correctItems = GetRandomElements(items, levelData.LevelIndex + 1);

        EventManager.Instance.OnGenerateNewLevel?.Invoke(correctItems.Count, levelData.CorrectColor);

        for (int i=0; i < items.Count; i++)
        {
            CreateButton(correctItems.Contains(items[i]));
        }
    }

    private void ClearPreviousData()
    {
        colors.Clear();
        for(int i=0; i<panelButtons.transform.childCount; i++)
        {
            Destroy(panelButtons.GetChild(i).gameObject);
        }
    }

    private void CreateButton(bool correctButton)
    {
        GameObject tmpButton = Instantiate(buttonPrefab,panelButtons);

        tmpButton.GetComponent<Image>().color = correctButton == false ? GenerateColor() : levelData.CorrectColor;
        tmpButton.AddComponent<ButtonAnswer>().Initialize(currentAniamtion, levelData, correctButton);
    }

    private Color GenerateColor()
    {
        Color cachedColor;

        do
        {
            cachedColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        }
        while (colors.Contains(cachedColor) == true);

        colors.Add(cachedColor);

        return cachedColor;
    }

    private void SetUpAnimation()
    {
        int random = UnityEngine.Random.Range(0, 120);
        currentAniamtion = new SpecialAnimation();
        if (random < 30)
        {
            currentAniamtion = new FadeAnimation();
        }
        else if (random < 60)
        {
            currentAniamtion = new ScaleAnimation();
        }
        else
        {
            currentAniamtion = new SpecialAnimation();
        }
    }

    private  List<int> GetRandomElements(IEnumerable<int> list, int elementsCount)
    {
        return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
    }
}


