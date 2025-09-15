using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    private InputAction _movement;



    private Invoker _invoker;

    private void Start()
    {
        _inputActions = new InputSystem_Actions();
        Bind();
    }

    private void Bind()
    {
        _movement = _inputActions.Player.Move;
        _movement.Enable();

        _inputActions.Player.Attack.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        _invoker.InvokeShoot();
    }

    private void FixedUpdate()
    {
        Move();
        ShootDirection();
    }

    private void Move()
    {
        Vector2 movement2D = _movement.ReadValue<Vector2>().normalized;
        _invoker.InvokeMove(movement2D);
    }

    private void ShootDirection()
    {
        _invoker.InvokeShootDirection(Input.mousePosition);
    }

    private void OnDestroy()
    {
        _movement.Disable();
    }

    private void Expose()
    {
            //_mainInputActions.Game.Shoot.performed -= Shoot;
    }

    public void Construct(Invoker invoker)
    {
        _invoker = invoker;
    }
}
