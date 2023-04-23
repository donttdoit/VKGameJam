using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private AudioManager _audioManager;
    private void Start()
    {
        _text.SetText("ВЫ ЗАВЕРШИЛИ ИГРУ");
    }

    public void ToMainMenu()
    {
        _audioManager.PlayButtonSFX();
        SceneManager.LoadScene("MainMenu");
    }
}