using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Flask,
        GreenPotion,
        Flower,
        Heal,
        Projectile
    }

    public ItemType itemType;
    public int amount;

    //private TMP_Text _textAmount;

    //private void Awake()
    //{
    //    _textAmount = GetComponentInChildren<TMP_Text>();
    //}

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Flask: return ItemAssets.Instance.Flask;
            case ItemType.Flower: return ItemAssets.Instance.Flower;
            case ItemType.GreenPotion: return ItemAssets.Instance.GreenPotion;  
            case ItemType.Heal: return ItemAssets.Instance.Heal;
            case ItemType.Projectile: return ItemAssets.Instance.Projectile;
        }
    }

    //public bool IsStackable()
    //{
    //    switch (itemType)
    //    {
    //        default:
    //        case ItemType.Flask:
    //            return true;
    //        case ItemType.Flower:
    //        case ItemType.GreenPotion:
    //            return false;
    //    }
    //}

}
