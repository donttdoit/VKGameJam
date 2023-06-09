using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestsManager : MonoBehaviour
{
    private static List<Quest> _quests = new List<Quest>();
    private static List<int> _tasks = new List<int>(); // count off added item
    private static List<String> _sceneOrder = new List<string>();
    private static int _currentQuestIndex = -1;
    private static int _currentSceneIndex = -1;
    private static int _currentTaskIndex = -1;


    private void Awake()
    {
        _quests.Add(new Quest(2, 1));
        _currentQuestIndex = 0;
        
        _tasks.Add(0);
        _tasks.Add(2);
        _tasks.Add(3);
        _tasks.Add(6);
        _tasks.Add(8);
        _tasks.Add(8);
        _currentTaskIndex = 0;

        _sceneOrder.Add("BombidariumFirst");
        _sceneOrder.Add("Level1");
        _sceneOrder.Add("Level2");
        _sceneOrder.Add("Level3");
        _sceneOrder.Add("Level4");
        _sceneOrder.Add("Bombidarium");
        _currentSceneIndex = 0;
    }

    public void FinishQuest()
    {
        _quests[_currentQuestIndex].FinishQuest();
        SceneManager.LoadScene("LevelFinish");
        //StartNextQuestOrEndGame();
    }


    public void LoadSceneById(int id)
    {
        SceneManager.LoadScene(_sceneOrder[id]);
    }

    public void LoadNextScene()
    {
        if (_currentSceneIndex < _sceneOrder.Count)
        {
            SceneManager.LoadScene(_sceneOrder[++_currentSceneIndex]);
            if (_currentTaskIndex < _tasks.Count) _currentTaskIndex++;
        }
        else
        {
            StartNextQuestOrEndGame();
        }
        
        //Debug.Log("CurScene:" + _sceneOrder[_currentSceneIndex + 1]);
    }

    public String GetCurrentSceneName()
    {
        return _sceneOrder[_currentSceneIndex];
    }

    public void LoadMainScene()
    {
        _currentQuestIndex = 0;
        _currentSceneIndex = 0;
        _currentTaskIndex = 0;
        LoadSceneById(0);
    }

    public Quest GetCurrentQuest()
    {
        return _quests[_currentQuestIndex];
    }

    public int GetCurrentQuestId()
    {
        return _currentQuestIndex;
    }

    public int GetCurrentTask()
    {
        return _tasks[_currentTaskIndex];
    }

    public int GetCurrentTaskId()
    {
        return _currentTaskIndex;
    }


    private void StartNextQuestOrEndGame()
    {
        _currentSceneIndex += 1;
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
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("LevelFinish");
    }

    private void EndGame()
    {
        SceneManager.LoadScene("GamelFinish");
    }
}