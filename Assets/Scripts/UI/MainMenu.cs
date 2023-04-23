using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;

    private const string SCENE_NAME = "LubaScene";

    public void PlayGame()
    {
        _audioManager.PlayButtonSFX();
        DontDestroyOnLoad(_audioManager.gameObject);
        SceneManager.LoadScene(SCENE_NAME);
    }

    public void SetMusicSlider(float volume)
    {
        _audioManager.SetMusicVolume(volume);
    }

    public void SetSFXSlider(float volume)
    {
        _audioManager.SetSFXVolume(volume);
    }
}