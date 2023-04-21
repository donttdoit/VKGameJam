using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    // Радиус взаимодействия с игроком
    [SerializeField] private float _actionRadius = 1f;

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit2D hit = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), _actionRadius, Vector2.zero);

    //        if (hit.collider && hit.collider.gameObject.CompareTag("Action"))
    //        {
    //            Debug.Log("Action");
    //        }
    //    }
    //}
    //    private void OnMouseDown()
    //{
    //    RaycastHit hit;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    //if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Player"))
    //    //{
    //    //    //MyMethod();
    //    //    Debug.Log("Action");
    //    //}

    //    if (Physics2D.CircleCast(ray.origin, 0.5f, ray.direction, out hit))
    //    {
    //        if (hit.collider.gameObject == gameObject)
    //        {
    //            Debug.Log("Action");
    //        }
    //    }
    //}


    //private void MyMethod()
    //{
    //    // Обработка нажатия на объект
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("Some1");
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Some2");
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Debug.Log("Action");
    //        }
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("Some1");
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Some2");
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Debug.Log("Action");
    //        }
    //    }
    //}
}
