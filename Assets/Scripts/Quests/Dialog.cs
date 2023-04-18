using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogText;

    [SerializeField] private QuestsManager _questsManager;

    private Animator _animator;

    private const string DIALOG_TRIGGER_NAME = "dialogTrigger";

   private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.GetComponent<>())
        //{
            SetDialogText();
            _animator.SetTrigger(DIALOG_TRIGGER_NAME);
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.GetComponent<>())
        //{
            _animator.SetTrigger(DIALOG_TRIGGER_NAME);
        //}
    }
    
    private void SetDialogText()
    {
        var currentQuest = _questsManager.GetCurrentQuest();
        if (currentQuest.IsFinished())
        {
            _dialogText.SetText("Отдай это пчелам");
        }
        else
        {
            var dialogText = "Пылинки " + currentQuest.GetPollenAmount() + System.Environment.NewLine + "Пушинки " +
                             currentQuest.GetFluffAmount();
            _dialogText.SetText(dialogText);
        }
    }
}