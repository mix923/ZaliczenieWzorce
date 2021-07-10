using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    public UnityEvent OnClickCorrectAnswer;
    public UnityEvent<int, Color> OnGenerateNewLevel;
    public UnityEvent OnCompleteLevel;
    public UnityEvent OnGameOverLevel;
}
