using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    private static List<Quest> _quests = new List<Quest>();
    private static int _currentQuestIndex = -1;

    private void Awake()
    {
        _quests.Add(new Quest(2, 1));
        _quests.Add(new Quest(3, 2));
        _currentQuestIndex = 0;
    }

    public void StartNextQuestOrFinish()
    {
        if (_currentQuestIndex + 1 <= _quests.Count - 1)
        {
            _currentQuestIndex += 1;
        }
        else
        {
            EndGame();
        }
    }

    public void FinishQuest()
    {
        _quests[_currentQuestIndex].FinishQuest();
    }

    public Quest GetCurrentQuest()
    {
        return _quests[_currentQuestIndex];
    }

    private void EndGame()
    {
        Debug.Log("The End");
    }
}