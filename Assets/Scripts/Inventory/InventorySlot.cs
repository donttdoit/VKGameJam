using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class InventorySlot : MonoBehaviour, IDropHandler
{
    private void FixedUpdate()
    {
        if (!IsFreeSlot())
        {
            TMP_Text textAmount = GetComponentInChildren<TMP_Text>();
            Item item = GetComponentInChildren<Item>();
            textAmount.text = item.amount.ToString();
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (IsFreeSlot())
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.ParentAfterDrag = transform;
        }
        else
        {
            Item droppedItem = eventData.pointerDrag.GetComponent<Item>();
            Item currentItem = GetComponentInChildren<Item>();
            if (droppedItem.itemType == currentItem.itemType)
            {
                currentItem.amount += droppedItem.amount;
                Destroy(eventData.pointerDrag);
            }
        }

        //GameObject dropped = eventData.pointerDrag;
        //Item draggableItem = dropped.GetComponent<Item>();
        //// Если слот не пустой
        //if (!IsFreeSlot())
        //{
        //    Debug.Log("1");
        //    Item item = GetComponentInChildren<Item>();
        //    // Если нужный тип предмета
        //    if (item.itemType == draggableItem.itemType)
        //    {
        //        item.amount += draggableItem.amount;
        //        Destroy(dropped);
        //    }
        //}
        //// Если же слот пустой
        //else
        //{
        //    DraggableItem draggablObject = dropped.GetComponent<DraggableItem>();
        //    draggablObject.ParentAfterDrag = transform;
        //    Debug.Log("2");
        //}
    }


    private bool IsFreeSlot() => transform.childCount == 0;
}
