//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class UI_Inventory : MonoBehaviour
//{
//    //[SerializeField] private int _rowCount = 4;

//    private int _maxCountItems = 4;

//    private Inventory _inventory;
//    private Transform _itemSlotContainer;
//    private Transform _itemSlotTemplate;

//    private void Awake()
//    {
//        _itemSlotContainer = transform.Find("itemSlotContainer");
//        _itemSlotTemplate = _itemSlotContainer.Find("ItemSlotTemplate");
//    }

//    public void SetInventory(Inventory inventory)
//    {
//        _inventory = inventory;
//        _inventory.OnItemListChanged += Inventory_OnItemListChanged;
//        RefreshInventoryItems();
//    }

//    private void Inventory_OnItemListChanged(object sender, EventArgs e)
//    {
//        RefreshInventoryItems();
//    }

//    private void RefreshInventoryItems()
//    {
//        foreach (Transform child in _itemSlotContainer)
//        {
//            if (child != _itemSlotTemplate) Destroy(child.gameObject);
//        }

//        int x = 0, y = 0;
//        float itemSlotCellSize = 80f;

//        // Расстановка слотов инвентаря
//        foreach (Item item in _inventory.GetItemList())
//        {
//            RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
//            itemSlotRectTransform.gameObject.SetActive(true);
//            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, 0);
//            //itemSlotRectTransform.anchoredPosition = new Vector2(-100, 0);

//            // Установка спрайта и текста для каждого слота
//            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
//            image.sprite = item.GetSprite();
//            TextMeshProUGUI text = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
//            if (item.amount > 1)
//            {
//                text.SetText(item.amount.ToString());
//            }
//            else
//            {
//                Debug.Log("No");
//                text.SetText("");
//            }

//            x++;
//            //if (x > _maxCountItems)
//            //{
//            //    x = 0;
//            //    y++;
//            //}
//        }

//        //for (int i = 0; i <)
//    }
//}
