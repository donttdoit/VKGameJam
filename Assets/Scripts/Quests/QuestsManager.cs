using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void FinishQuest()
    {
        _quests[_currentQuestIndex].FinishQuest();
        StartNextQuestOrEndGame();
    }

    public Quest GetCurrentQuest()
    {
        return _quests[_currentQuestIndex];
    }

    public int GetCurrentQuestId()
    {
        return _currentQuestIndex;
    }

    private void StartNextQuestOrEndGame()
    {
        if (_currentQuestIndex + 1 <= _quests.Count - 1)
        {
            _currentQuestIndex += 1;
            StartNextQuest();
        }
        else
        {
            EndGame();
        }
    }
    private void StartNextQuest()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("LevelFinish");
    }
    private void EndGame()
    {
        SceneManager.LoadScene("GameFinish");
    }
}