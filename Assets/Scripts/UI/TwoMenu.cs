using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TwoMenu : MonoBehaviour
{
    private QuestsManager _questsManager;
    [SerializeField] private TMP_Text _text;


    private void Start()
    {
        //_text.SetText("Найдите нужные Шмелю-матке предметы для починки бомбидария, отдайте их рабочим шмелям. Чтобы собрать предмет, нужно нажать на него и подлететь. Сражайтесь с врагами. Собирайте шишки, подлетайте поближе к врагам и бросайте шишки двойным кликом во врагов. Восполняйте здоровье. Собирайте лечебные травы и используйте их из инвентаря.");

    }

    public void PlayGame()
    {
        _questsManager = FindObjectOfType<QuestsManager>();
        _questsManager.LoadSceneById(0);
    }
}
