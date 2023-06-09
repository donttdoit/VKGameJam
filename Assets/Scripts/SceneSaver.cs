using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSaver : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _itemAssets;
    [SerializeField] private SignToLevel _signToLevel;


    private void Start()
    {
        DontDestroyOnLoad(_ui);
        DontDestroyOnLoad(_player);
        DontDestroyOnLoad(_itemAssets);
        DontDestroyOnLoad(_signToLevel);
    }
}
