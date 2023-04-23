using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignToLevel : MonoBehaviour
{
    private QuestsManager _questsManager;
    private Inventory _inventory;

    private void Start()
    {
        _questsManager = FindObjectOfType<QuestsManager>();
        _inventory = FindObjectOfType<Inventory>();
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log("enter");
    //     _questsManager.LoadNextScene();
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // int itemCount = 0;
        // foreach (Transform itemSlot in _inventory.transform)
        // {
        //     if (itemSlot.childCount > 0)
        //     {
        //         itemCount += itemSlot.childCount;
        //     }
        // }

        if (_inventory.InventoryCounter == _questsManager.GetCurrentTask())
        {
            Debug.Log("fine");
            _questsManager.LoadNextScene();
        }
    }
}
