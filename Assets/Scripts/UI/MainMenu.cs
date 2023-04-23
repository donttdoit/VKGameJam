using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private QuestsManager _questsManager;

    public void PlayGame()
    {
        _audioManager.PlayButtonSFX();
        DontDestroyOnLoad(_audioManager.gameObject);
        DontDestroyOnLoad(_questsManager.gameObject);
        SceneManager.LoadScene("Ruls");
    }

    public void SetMusicSlider(float volume)
    {
        _audioManager.PlayButtonSFX();
        _audioManager.SetMusicVolume(volume);
    }

    public void SetSFXSlider(float volume)
    {
        _audioManager.PlayButtonSFX();
        _audioManager.SetSFXVolume(volume);
    }
}