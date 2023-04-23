using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector3 _target;
    private int _damage;
    //private float _timeToDestroy = 5f;
    //private float _currentTime;

    private void FixedUpdate()
    {
        //_currentTime += Time.deltaTime;
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void SetTarget(Vector3 target) => _target = target;

    public void SetDamage(int damage) => _damage = damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}
