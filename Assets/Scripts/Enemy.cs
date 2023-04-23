using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp = 3;
    [SerializeField] private int _damage = 3;
    [SerializeField] private float _speed = 5f;

    //public bool IsAgressive;

    private Player _player;
    //private Slider _hpSlider;

    private void Update()
    {
        if (!IsAlive())
        {
            Dead();
        }
    }

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //_hpSlider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    private void Start()
    {
        //_hpSlider.maxValue = _hp;
        //_hpSlider.value = _hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Fight");
        if (collision.gameObject.CompareTag("Player"))
        { 
            Attack();
        }
    }

    private void Attack()
    {
        _player.TakeDamage(_damage);
        //Destroy(gameObject);
    }

    public float GetSpeed() => _speed;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        //_hpSlider.value = _hp;
    }

    public bool IsAlive() => _hp > 0;

    public void Dead()
    {
        //_hpSlider.value = 0;
        Destroy(gameObject);
    }
}
