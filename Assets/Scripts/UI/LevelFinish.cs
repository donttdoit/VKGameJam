using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;

   private QuestsManager _questsManager;
   private AudioManager _audioManager;

   private void Awake()
   {
      _questsManager = FindObjectOfType<QuestsManager>();
      _audioManager = FindObjectOfType<AudioManager>();
   }

   private void Start()
   {
      _text.SetText("ВЫ ПРОШЛИ " + _questsManager.GetCurrentQuestId() + " УРОВЕНЬ");
   }

   public void ToMainMenu()
   {
      _audioManager.PlayButtonSFX();
      Destroy(_audioManager.gameObject);
      Destroy(_questsManager.gameObject);
      SceneManager.LoadScene("MainMenu");
   }

   public void ToNextLevel()
   {
      _audioManager.PlayButtonSFX();
      _questsManager.LoadNextLevel();
   }
}
