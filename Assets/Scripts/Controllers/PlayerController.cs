using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction PlayerMovementAndInteract;
    [SerializeField] InputAction PlayerAttack;
    [SerializeField] private InputAction DragAndDrop;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Vector2 _moveDirection;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        PlayerMovementAndInteract.performed += MoveAndInteract;
        PlayerAttack.performed += Atack;
        DragAndDrop.performed += MousePressed;
        
        PlayerMovementAndInteract.Enable();
        PlayerAttack.Enable();
        DragAndDrop.Enable();
    }

    private void OnDisable()
    {
        PlayerMovementAndInteract.performed -= MoveAndInteract;
        PlayerAttack.performed -= Atack;
        DragAndDrop.performed -= MousePressed;
        
        PlayerMovementAndInteract.Disable();
        PlayerAttack.Disable();
        DragAndDrop.Disable();
    }

    private void MoveAndInteract(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (_coroutine != null) StopCoroutine(_coroutine);
        if (hit)
        {
            Debug.Log(("hit"));
            //_coroutine = StartCoroutine(PlayerMoveTowards(hit.point, 0.1f));
        }
        else
        {
            Debug.Log(("no hit"));
            _coroutine = StartCoroutine(PlayerMoveTowards(mousePos, 0.1f));
        }
    }

    private IEnumerator PlayerMoveTowards(Vector2 target, float radius)
    {
        while (Vector2.Distance(transform.position, target) > radius)
        {
            Vector2 destination = Vector2.MoveTowards(transform.position, target, _moveSpeed * Time.deltaTime);
            transform.position = destination;
            yield return null;
        }
    }

    private void Atack(InputAction.CallbackContext context)
    {
        Debug.Log("two");
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        
    }
}