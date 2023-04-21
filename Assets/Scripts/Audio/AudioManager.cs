using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _buttonSFX;

    private const string MIXER_MUSIC = "MusicVolume";
    private const string MIXER_SFX = "SFXVolume";

    private void Awake()
    {
        _music = GetComponentInChildren<AudioSource>();
    }

    public void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    public void PlayMusic()
    {
        _music.Play();
    }

    public void PlayButtonSFX()
    {
        _buttonSFX.Play();
    }
}