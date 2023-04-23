using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _hp = 3;
    [SerializeField] private int _damage = 3;
    [SerializeField] private float _speed = 5f;

    private AudioSource _audioSourceBee;

    private int _maxHp = 3;
    //[SerializeField] private float _attackRadius = 0.5f; // ������ �������������� ������ ������

    private Inventory _inventory;

    private Slider _hpSlider;
    //private UI_Inventory _ui_inventory;

    private Vector3 _targetToMove;

    private const float _DOUBLE_CLICK_TIME = .3f;
    private float _lastClickTime;
    public bool _canMove;
    private bool _canAttack;

    public Inventory GetInventory() => _inventory;

    private void Awake()
    {
        //_inventory = new Inventory();
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        _hpSlider = GameObject.Find("Slider").GetComponent<Slider>();
        //_ui_inventory = FindObjectOfType<UI_Inventory>();
        //_ui_inventory.SetInventory(_inventory);
        _audioSourceBee = GameObject.Find("BeeSound").GetComponent<AudioSource>();
    }

    private void Start()
    {
        _targetToMove = transform.position;
        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _hp;
    }

    private void Update()
    {
        //Debug.Log("canMove: "+_canMove);
        if (IsAlive())
        {
            //CheckActionArea();
            Click();
            Move();
            //Move();
        }
        else
        {
            //Debug.Log("GameOver");
            Dead();
        }


    }



    private void Click()
    {

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                _canMove = true;
            }
            else
            {
                _canMove = false;
            }

            float timeSinceLastClick = Time.time - _lastClickTime;

            // Double click
            if (timeSinceLastClick < _DOUBLE_CLICK_TIME)
            {
                if (_canAttack)
                {
                    Attack();
                }
            }

            // Normal click
            else
            {
                _audioSourceBee.Play();
            }

            _lastClickTime = Time.time;
        }
    }


    private void Move()
    {
        if (_canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _targetToMove = GetMousePosition();
            }

            transform.position = Vector3.MoveTowards(transform.position, _targetToMove, _speed * Time.deltaTime);
            if ((_targetToMove - transform.position) != Vector3.zero)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = (_targetToMove - transform.position).x < 0;
            }
            else
            {
                _canMove = false;
            }
        }
        else
        {
            _audioSourceBee.Pause();
        }
    }


    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        return mousePosition;
    }

    public bool IsAlive() => _hp > 0;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        _hpSlider.value = _hp;
    }

    public int GetHp() => _hp;

    public void SetHp(int hp)
    {
        if (hp < _maxHp)
        {
            _hp = hp;
            _hpSlider.value = _hp;
        }
    }

    public void Dead()
    {
        _hpSlider.value = _hpSlider.maxValue;
        SceneManager.LoadScene("Death");
        Debug.Log("Game Over");
    }

    private void Attack()
    {
        float attackRadius = 3f;
        RaycastHit2D hit = Physics2D.CircleCast(GetMousePosition(), attackRadius, Vector2.zero);
        if (hit.collider && hit.collider.gameObject.CompareTag("Enemy"))
        {
            Item item = _inventory.GetProjectileItem();
            if (item)
            {
                GameObject projectile = Instantiate(ItemAssets.Instance.ProjectilePrefab, transform.position,
                    Quaternion.identity);
                Projectile projectileObj = projectile.GetComponent<Projectile>();
                projectileObj.SetTarget(hit.collider.gameObject.transform.position);
                projectileObj.SetDamage(_damage);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��������� ������� � ���������
        if (collision.gameObject.CompareTag("Item"))
        {
            Item item = collision.gameObject.GetComponent<Item>();
            if (_inventory.AddItem(item))
            {
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("AngryCollision"))
        {
            _canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AngryCollision"))
        {
            _canAttack = false;
        }
    }
}