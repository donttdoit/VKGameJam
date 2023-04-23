using System;
using UnityEngine;

public class Bees : MonoBehaviour
{
    private CheckSlot _checkSlot;
    private Animator _animator;
    private QuestsManager _questsManager;

    private void OnEnable()
    {
        
    }

    public void OnDisable()
    {
        _checkSlot.Getted -= MakeHoneyCombs;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _questsManager = FindObjectOfType<QuestsManager>();
        _checkSlot = FindObjectOfType<CheckSlot>();
        _checkSlot.Getted += MakeHoneyCombs;
    }


    private void MakeHoneyCombs()
    {
        _animator.SetTrigger("getHoney");
    }

    public void OnAnimationFinished()
    {
        Debug.Log("eeee");
        _questsManager.FinishQuest();
    }
}