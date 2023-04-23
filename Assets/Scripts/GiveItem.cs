using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class GiveItem : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (hit.collider.name == name)
                {
                    GetComponentInChildren<Item>(true).gameObject.SetActive(true);
                }
            }
        }
        
    }
}
