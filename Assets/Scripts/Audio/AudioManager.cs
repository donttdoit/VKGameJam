using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _buttonSFX;
    [SerializeField] private AudioSource _beeSFX;

    private const string MIXER_MUSIC = "MusicVolume";
    private const string MIXER_SFX = "SFXVolume";

    private const float _beeSFXTime = 3.0f;

    private void Awake()
    {
        _music = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        if(_beeSFX.time > 3.0){
            _beeSFX.Stop();
        }
    }

    public void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        _beeSFX.Play();
    }

    public void PlayMusic()
    {
        _music.Play();
    }

    public void PlayButtonSFX()
    {
        _buttonSFX.Play();
    }

    public void PlayBeeSFX()
    {
        _beeSFX.Play();
    }
}