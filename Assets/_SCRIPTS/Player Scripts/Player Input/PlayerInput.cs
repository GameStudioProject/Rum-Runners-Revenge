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
    public bool PlayerGrabInput { get; private set; }

    [SerializeField] private float _playerInputHoldTime = 0.2f;

    private float _playerJumpInputStartTime;

    private void Update()
    {
        CheckPlayerJumpInputHoldTime();
    }

    public void OnMovementInput(InputAction.CallbackContext button)
    {
        RawPlayerMovementInput = button.ReadValue<Vector2>();

        if (Mathf.Abs(RawPlayerMovementInput.x) > 0.5f)
        {
            NormInputX = (int)(RawPlayerMovementInput * Vector2.right).normalized.x;   
        }
        else
        {
            NormInputX = 0;
        }

        if (Mathf.Abs(RawPlayerMovementInput.y) > 0.5f)
        {
            NormInputY = (int)(RawPlayerMovementInput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
        
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

    public void OnPlayerGrabInput( InputAction.CallbackContext button)
    {
        if (button.started)
        {
            PlayerGrabInput = true;
        }

        if (button.canceled)
        {
            PlayerGrabInput = false;
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
