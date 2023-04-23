using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        None,
        Pollen,
        Fluff,
        Grass,
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
            case ItemType.Pollen: return ItemAssets.Instance.Pollen;
            case ItemType.Fluff: return ItemAssets.Instance.Fluff;
            case ItemType.Grass: return ItemAssets.Instance.Grass;
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
