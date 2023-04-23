using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;
   [SerializeField] private String _nextLevelScene;

   private QuestsManager _questsManager;
   private void Start()
   {
      _questsManager = FindObjectOfType<QuestsManager>();
      _text.SetText("ВЫ ПРОШЛИ " + _questsManager.GetCurrentQuestId() + " УРОВЕНЬ");
   }

   public void ToMainMenu()
   {
      SceneManager.LoadScene("MainMenu");
   }

   public void ToNextLevel()
   {
      SceneManager.LoadScene(_nextLevelScene);
   }
}
