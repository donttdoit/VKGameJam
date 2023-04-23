using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private AudioManager _audioManager;
    private QuestsManager _questsManager;
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _questsManager = FindObjectOfType<QuestsManager>();
        _text.SetText("ВЫ ПРОИГРАЛИ");
    }

    public void Retry()
    {
        _audioManager.PlayButtonSFX();
        SceneManager.LoadScene(_questsManager.GetCurrentSceneName());
    }
}
