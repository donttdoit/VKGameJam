using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [HideInInspector] public Transform ParentAfterDrag;
    private Image _image;
    private Player _player;


    private void Awake()
    {
        _image = GetComponent<Image>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag");
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("EndDrag");
        transform.SetParent(ParentAfterDrag);
        _image.raycastTarget = true;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Item item = eventData.pointerClick.gameObject.GetComponent<Item>();
            if (item.itemType == Item.ItemType.Heal)
            {
                _player.SetHp(_player.GetHp() + 1);
                Destroy(gameObject);
            }
        }
    }
}
