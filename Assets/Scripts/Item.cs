using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Flask,
        GreenPotion,
        Flower
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Flask: return ItemAssets.Instance.Flask;
            case ItemType.Flower: return ItemAssets.Instance.Flower;
            case ItemType.GreenPotion: return ItemAssets.Instance.GreenPotion;  
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Flask:
                return true;
            case ItemType.Flower:
            case ItemType.GreenPotion:
                return false;
        }
    }

}
