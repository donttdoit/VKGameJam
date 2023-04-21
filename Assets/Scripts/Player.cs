using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _actionRadius = 0.5f; // ������ �������������� ������ ������

    private Inventory _inventory;
    //private UI_Inventory _ui_inventory;

    private Vector3 _targetToMove;
    //private bool _canMove;

    public Inventory GetInventory() => _inventory;
    private void Awake()
    {
        _inventory = new Inventory();
        //_ui_inventory = FindObjectOfType<UI_Inventory>();
        //_ui_inventory.SetInventory(_inventory);
    }

    private void Start()
    {
        _targetToMove = transform.position;
    }

    private void Update()
    {
        CheckActionArea();
        Move();
    }

    // �������� �� ��������� ������ � ������ ��������������
    private void CheckActionArea()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y), _actionRadius, Vector2.zero);
            
            // ���� ���� �� Item, �� ��������� � ���������
            if (hit.collider && hit.collider.gameObject.CompareTag("Item"))
            {
                GameObject itemObject = hit.collider.gameObject;
                Item item = itemObject.GetComponent<Item>();
                _inventory.AddItem(item);
                Destroy(itemObject);
                Debug.Log("Action");
            }
        }
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            _targetToMove = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetToMove.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetToMove, _speed * Time.deltaTime);
  
    }

}