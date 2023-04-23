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
        _audioManager = FindObjectOfType<AudioManager>();
        _text.SetText("ВЫ ЗАВЕРШИЛИ ИГРУ");
    }

    public void ToMainMenu()
    {
        _audioManager.PlayButtonSFX();
        Destroy(FindObjectOfType<SignToLevel>(true).gameObject);
        Destroy(FindObjectOfType<AudioManager>(true).gameObject);
        Destroy(FindObjectOfType<Player>(true).gameObject);
        Destroy(FindObjectOfType<ItemAssets>(true).gameObject);
        Destroy(FindObjectOfType<QuestsManager>(true).gameObject);
        Destroy(GameObject.Find("UI"));
        
        SceneManager.LoadScene("MainMenu");
    }
}