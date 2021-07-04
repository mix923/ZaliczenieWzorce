using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/Create")]
public class Level : ScriptableObject
{
    public int NumberOfButtonsToGuess { get; set; }
    public int LevelIndex { get; set; }
    public Color CorrectColor { get; set; }
}
