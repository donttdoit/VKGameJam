using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Player _player;
    private Transform _parent;
    private float _speed;
    SpriteRenderer _parentSprite;

    private bool _canMove;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        _parent = transform.parent;
        _speed = _parent.gameObject.GetComponent<Enemy>().GetSpeed();
        _parentSprite = _parent.gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            MoveToPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _canMove = true;
            //_parent.gameObject.GetComponent<Enemy>().IsAgressive = true;
        }
        if (_parentSprite) _parentSprite.flipX = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _canMove = false;
        //_parent.gameObject.GetComponent<Enemy>().IsAgressive = false;
    }

    private void MoveToPlayer()
    {
        _parent.position = Vector3.MoveTowards(_parent.position, _player.transform.position, _speed * Time.deltaTime);

        if ((_parent.position - _player.transform.position) != Vector3.zero)
        {
            _parentSprite.flipX = (_parent.position - _player.transform.position).x < 0;
        }
    }
}
