using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CheckSlot : MonoBehaviour, IDropHandler
{
    public event Action Getted;
    
    [SerializeField] private Item.ItemType _requiredItemType;
    [SerializeField] private int _requiredAmount;

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
        GameObject dropped = eventData.pointerDrag;
        Item draggableItem = dropped.GetComponent<Item>();
        // ���� ���� �� ������
        if (!IsFreeSlot())
        {

            Item item = GetComponentInChildren<Item>();
            // ���� ������ ��� ��������

            // ���� ������ ��� ��������

            if (IsRightType(draggableItem.itemType))
            {
                item.amount += draggableItem.amount;
                Destroy(dropped);


                CheckMissionComplete(item);

                
                // if (IsEnoughAmount(item.amount))
                // {
                //     Debug.Log("������� �� ����� �������");
                //     Getted?.Invoke();
                // }

            }
        }
        // ���� �� ���� ������
        else
        {
            DraggableItem draggablObject = dropped.GetComponent<DraggableItem>();
            draggablObject.ParentAfterDrag = transform;

            draggableItem = dropped.GetComponent<Item>();
            CheckMissionComplete(draggableItem);
        }
    }


    private bool IsFreeSlot() => transform.childCount == 0;
    private bool IsRightType(Item.ItemType itemType) => itemType == _requiredItemType;
    private bool IsEnoughAmount(int amount) => amount >= _requiredAmount;
    
    private void CheckMissionComplete(Item item)
    {
        if (IsRightType(item.itemType))
        {
            if (IsEnoughAmount(item.amount))
            {
                Debug.Log("������� �� ����� �������");
            }
        }
    }
}
