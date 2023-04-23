using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // [SerializeField] private TextMesh _dialogText1;
    // [SerializeField] private Image _dialogImage1;
    // [SerializeField] private TextMesh _dialogText2;
    // [SerializeField] private Image _dialogImage2;

    private QuestsManager _questsManager;

    private Animator _animator;

    private const string DIALOG_TRIGGER_NAME = "dialogTrigger";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _questsManager = FindObjectOfType<QuestsManager>();
    }

    public void OpenDialog()
    {
        //SetDialogText();
        _animator.SetTrigger(DIALOG_TRIGGER_NAME);
    }

    public void CloseDialog()
    {
        _animator.SetTrigger(DIALOG_TRIGGER_NAME);
    }


    // private void SetDialogText()
    // {
    //     var currentQuest = _questsManager.GetCurrentQuest();
    //     if (currentQuest.IsFinished())
    //     {
    //         _dialogText1.text = "Отдай это пчелам";
    //     }
    //     else
    //     {
    //         _dialogText1.text =  currentQuest.GetPollenAmount() + "";
    //         _dialogImage1.sprite = currentQuest.GetQuestItemPollen().GetSprite();
    //
    //         _dialogText2.text = currentQuest.GetFluffAmount() + "";
    //         _dialogImage2.sprite = currentQuest.GetQuestItemFluff().GetSprite();
    //     }
    // }
}