using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 RawPlayerMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool PlayerJumpInput { get; private set; }
    public bool PlayerJumpInputStop { get; private set; }

    [SerializeField] private float _playerInputHoldTime = 0.2f;

    private float _playerJumpInputStartTime;

    private void Update()
    {
        CheckPlayerJumpInputHoldTime();
    }

    public void OnMovementInput(InputAction.CallbackContext button)
    {
        RawPlayerMovementInput = button.ReadValue<Vector2>();

        NormInputX = (int)(RawPlayerMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawPlayerMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext button)
    {
        if (button.started)
        {
            PlayerJumpInput = true;
            PlayerJumpInputStop = false;
            _playerJumpInputStartTime = Time.time;
        }

        if (button.canceled)
        {
            PlayerJumpInputStop = true;
        }
    }
    
    

    public void PlayerUsedJumpInput() => PlayerJumpInput = false;

    private void CheckPlayerJumpInputHoldTime()
    {
        if (Time.time >= _playerJumpInputStartTime + _playerInputHoldTime)
        {
            PlayerJumpInput = false;
        }
    }
}    
