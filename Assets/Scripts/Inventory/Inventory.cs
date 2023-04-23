using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Transform _inventory;
    public int InventoryCounter = 0;

    private void Start()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Transform>();
    }

    public bool AddItem(Item item)
    {
        InventoryCounter++;
        
        Transform itemObject;
        Item newItem;
        Transform itemSlot = GetSlot(item.itemType);

        // ���� ���� ���� � ����� ���������
        if (itemSlot)
        {
            itemObject = itemSlot.GetChild(0);
            newItem = itemObject.GetComponent<Item>();

            newItem.amount += item.amount;
            return true;
        }
        // ���� ���, �� ���� ��������� ����
        else
        {
            int indexFreeSlot = GetFreeSlot();
            if (indexFreeSlot >= 0)
            {
                itemSlot = GetSlot(indexFreeSlot);
  
                Instantiate(ItemAssets.Instance.ItemPrefab, itemSlot);

                itemObject = itemSlot.GetChild(0);
                newItem = itemObject.GetComponent<Item>();

                newItem.itemType = item.itemType;
                newItem.amount = item.amount;
                itemObject.gameObject.GetComponent<Image>().sprite = newItem.GetSprite();

                return true;
            }
        }

        return false;
    }

    // ���������� ������ ���������� ����� ��� -1 ���� ��� ������
    public int GetFreeSlot()
    {
        int i = 0;
        foreach (Transform itemSlot in _inventory)
        {
            if (itemSlot.gameObject.transform.childCount == 0)
                return i;
            i++; 
        }

        return -1;
    }

    // ���������� ������ ����� �� �������
    public Transform GetSlot(int index)
    {
        int i = 0;
        foreach (Transform itemSlot in _inventory)
        {
            if (i == index)
                return itemSlot;
            i++;
        }
        return null;
    }

    // ���������� ������ ����� �� ����
    public Transform GetSlot(Item.ItemType itemType)
    {
        foreach (Transform itemSlot in _inventory)
        {
            if (itemSlot.childCount > 0) {
                Transform itemObject = itemSlot.GetChild(0);
                Item item = itemObject.GetComponent<Item>();

                if (item && item.itemType == itemType)
                    return itemSlot;
            }
        }
        return null;
    }

    // ������� ������� ������� �� ���������
    public Item GetProjectileItem()
    {
        foreach (Transform itemSlot in _inventory)
        {
            if (itemSlot.childCount > 0)
            {
                Transform itemObject = itemSlot.GetChild(0);
                Item item = itemObject.GetComponent<Item>();

                if (item && item.itemType == Item.ItemType.Projectile)
                {
                    item.amount--;
                    if (item.amount <= 0)
                    {
                        Destroy(itemObject.gameObject);
                    }
                    return item;
                }
                    
            }
        }

        return null;
    }
}
