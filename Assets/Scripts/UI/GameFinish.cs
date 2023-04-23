using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private QuestsManager _questsManager;
    private void Start()
    {
        _questsManager = FindObjectOfType<QuestsManager>();
        _text.SetText("ВЫ ЗАВЕРШИЛИ ИГРУ");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}