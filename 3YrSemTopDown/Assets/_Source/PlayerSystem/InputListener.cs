using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    private InputAction _movement;

    private Invoker _invoker;
    private Pause _pause;
    private PlayerHealth _playerHealth;

    public void Construct(Invoker invoker, Pause pause, PlayerHealth playerHealth)
    {
        _invoker = invoker;
        _pause = pause;
        _playerHealth = playerHealth;
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

    private void OnDisable()
    {
        Expose();
    }

    private void Bind()
    {
        _movement = _inputActions.Player.Move;
        _movement.Enable();

        _inputActions.Player.Attack.performed += Shoot;
        _inputActions.Player.Attack.Enable();

        _inputActions.UI.Cancel.performed += PauseGame;
        _inputActions.UI.Cancel.Enable();
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        _pause.PauseUnPauseGame();
    }
    
    public void PauseButtonGame()
    {
        _pause.PauseUnPauseGame();
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
        _inputActions.UI.Cancel.Disable();
    }

    public void ReviveByButton()
    {
        _playerHealth.Revive();
    }
}
