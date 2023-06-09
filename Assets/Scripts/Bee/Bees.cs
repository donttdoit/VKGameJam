using System;
using UnityEngine;

public class Bees : MonoBehaviour
{
    [SerializeField] private CheckSlot _checkSlot;
    
    private Animator _animator;
    private QuestsManager _questsManager;
    
    

    private void OnEnable()
    {
        _checkSlot.Getted += MakeHoneyCombs;
    }

    public void OnDisable()
    {
        _checkSlot.Getted -= MakeHoneyCombs;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _questsManager = FindObjectOfType<QuestsManager>();
        //_checkSlot = FindObjectOfType<CheckSlot>();
    }


    private void MakeHoneyCombs()
    {
        _animator.SetTrigger("getHoney");
    }

    public void OnAnimationFinished()
    {
        _questsManager.FinishQuest();
    }
}