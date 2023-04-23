using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignToLevel : MonoBehaviour
{
    private QuestsManager _questsManager;

    private void Start()
    {
        _questsManager = FindObjectOfType<QuestsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        _questsManager.LoadNextLevel();
    }
}
