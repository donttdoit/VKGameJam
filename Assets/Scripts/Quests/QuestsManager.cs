using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestsManager : MonoBehaviour
{
    private static List<Quest> _quests = new List<Quest>();
    private static List<String> _sceneOrder = new List<string>();
    private static int _currentQuestIndex = -1;
    private static int _currentSceneIndex = -1;

    private void Awake()
    {
        _quests.Add(new Quest(2, 1));
        _quests.Add(new Quest(3, 2));
        _currentQuestIndex = 0;
        
        _sceneOrder.Add("BombidariumFirst");
        _sceneOrder.Add("MaxScene");
        _sceneOrder.Add("Bombidarium");
        // level finish
        _sceneOrder.Add("MaxScene");
        _sceneOrder.Add("Bombidarium");
        // level finish
        _sceneOrder.Add("MaxScene");
        _sceneOrder.Add("Bombidarium");
        //game finish
        _currentSceneIndex = 0;
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

    public void LoadLevelById(int id)
    {
        SceneManager.LoadScene(_sceneOrder[id]);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_sceneOrder[_currentSceneIndex + 1]);
    }

    public int GetCurrentQuestId()
    {
        return _currentQuestIndex;
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
        SceneManager.LoadScene("GameFinish");
    }
}