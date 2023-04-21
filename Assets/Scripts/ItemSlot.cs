using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public bool IsOpen;

    private RectTransform _rectTransform;
    
    //private Player _player;
    private Item _item;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        //_player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag)
        {
            //foreach (Item item in _player.GetInventory().GetItemList())
            //{
            //    Debug.Log($"{item.GetComponent<RectTransform>()}");
            //}
            eventData.pointerDrag.GetComponent<RectTransform>().position = _rectTransform.position;
            
        }
    }
}
