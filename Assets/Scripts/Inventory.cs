using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Transform _inventory;

    //private Transform _ui_inventory;
    private int _maxCountItems = 5;

    //public EventHandler OnItemListChanged;

    private void Start()
    {
        //_itemList = new List<Item>();
    }

    public Inventory()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Transform>();

        //AddItem(new Item { itemType = Item.ItemType.Flask, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Flower, amount = 2 });
        //AddItem(new Item { itemType = Item.ItemType.GreenPotion, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.GreenPotion, amount = 1 });
        //_ui_inventory = GameObject.Find("ItemSlotContainer").GetComponent<Transform>();

        //Debug.Log(_itemList.Count);
    }

    public void AddItem(Item item)
    {
        Transform itemObject;
        Item newItem;
        Transform itemSlot = GetSlot(item.itemType);
        // Если есть слот с таким предметом
        if (itemSlot)
        {
            itemObject = itemSlot.GetChild(0);
            newItem = itemObject.GetComponent<Item>();

            newItem.amount += item.amount;
        }
        // Если нет, то ищем свободный слот
        else
        {
            int indexFreeSlot = GetFreeSlot();
            if (indexFreeSlot > 0)
            {
                itemSlot = GetSlot(indexFreeSlot);
                Instantiate(ItemAssets.Instance.ItemPrefab, itemSlot);

                itemObject = itemSlot.GetChild(0);
                newItem = itemObject.GetComponent<Item>();

                newItem.itemType = item.itemType;
                newItem.amount = item.amount;
                itemObject.gameObject.GetComponent<Image>().sprite = newItem.GetSprite();

            }
        }
        
            //foreach (Transform itemSlot in _ui_inventory)
            //{
            //    //itemSlot.gameObject.
            //}


            //// Если предмет стакается то добавляем количество, если нет, то просто добавляем
            //if (item.IsStackable())
            //{
            //    bool itemAlreadyInInventory = false;
            //    foreach (Item inventoryItem in _itemList)
            //    {
            //        if (inventoryItem.itemType == item.itemType)
            //        {
            //            inventoryItem.amount += item.amount;
            //            itemAlreadyInInventory = true;
            //        }
            //    }

            //    if (!itemAlreadyInInventory)
            //    {
            //        _itemList.Add(item);
            //    }
            //}
            //else
            //{
            //    _itemList.Add(item);
            //}

            //OnItemListChanged?.Invoke(this, EventArgs.Empty);
         
    }

    public void RemoveItem(Item item)
    {
        //_itemList.Remove(item);
        //OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    // Возвращает индекс свободного слота или -1 если все занято
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

    // Возвращает объект слота по индексу
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

    // Возвращает объект слота по типу
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

    //public List<Item> GetItemList() => _itemList;
}
