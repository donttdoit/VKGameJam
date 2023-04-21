using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction PlayerMovementAndInteract;
    [SerializeField] InputAction PlayerAttack;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Vector2 _moveDirection;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        PlayerMovementAndInteract.performed += MoveAndInteract;
        PlayerMovementAndInteract.Enable();
    }

    private void OnDisable()
    {
        PlayerMovementAndInteract.performed -= MoveAndInteract;
        PlayerMovementAndInteract.Disable();
    }

    private void MoveAndInteract(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(PlayerMoveTowards(hit.point));
            if (hit.collider)
            {
            }
        }
    }

    private IEnumerator PlayerMoveTowards(Vector2 target)
    {
        while (Vector2.Distance(transform.position, target) > 0.1f)
        {
            Vector2 destination = Vector2.MoveTowards(transform.position, target, _moveSpeed * Time.deltaTime);
            transform.position = destination;
            yield return null;
        }
    }
}