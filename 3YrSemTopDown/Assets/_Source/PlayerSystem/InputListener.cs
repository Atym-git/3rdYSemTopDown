using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    private InputAction _movement;

    private Invoker _invoker;

    public void Construct(Invoker invoker)
    {
        _invoker = invoker;
    }

    private void Start()
    {
        _inputActions = new InputSystem_Actions();
        Bind();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDestroy()
    {
        Expose();
    }

    private void Bind()
    {
        _movement = _inputActions.Player.Move;
        _movement.Enable();

        _inputActions.Player.Attack.performed += Shoot;
        _inputActions.Player.Attack.Enable();
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        _invoker.InvokeShoot();
    }

    private void Move()
    {
        Vector2 movement2D = _movement.ReadValue<Vector2>().normalized;
        _invoker.InvokeMove(movement2D);
    }

    private void Expose()
    {
        _movement.Disable();
        _inputActions.Player.Attack.Disable();
    }

}
