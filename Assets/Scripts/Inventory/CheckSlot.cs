using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Item.ItemType _requiredItemType;
    [SerializeField] private int _requiredAmount;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Item draggableItem = dropped.GetComponent<Item>();
        // Если слот не пустой
        if (!IsFreeSlot())
        {
            // Если нужный тип предмета
            if (IsRightType(draggableItem.itemType))
            {
                Item item = GetComponentInChildren<Item>();
                item.amount += draggableItem.amount;
                Destroy(dropped);
                
                if (IsEnoughAmount(item.amount))
                {
                    Debug.Log("Переход на новый уровень");
                }
            }
        }
        // Если же слот пустой
        else
        {
            DraggableItem draggablObject = dropped.GetComponent<DraggableItem>();
            draggablObject.ParentAfterDrag = transform;

        }
    }


    private bool IsFreeSlot() => transform.childCount == 0;
    private bool IsRightType(Item.ItemType itemType) => itemType == _requiredItemType;
    private bool IsEnoughAmount(int amount) => _requiredAmount >= amount;
    
}
