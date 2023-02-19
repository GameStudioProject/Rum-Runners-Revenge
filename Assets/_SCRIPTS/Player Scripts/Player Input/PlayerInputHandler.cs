using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Camera _camera;
    
    public Vector2 RawPlayerMovementInput { get; private set; }
    
    public Vector2 RawPlayerDashDirectionInput { get; private set; }
    public Vector2Int PlayerDashDirectionInput { get; private set; }
    
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool PlayerJumpInput { get; private set; }
    public bool PlayerJumpInputStop { get; private set; }
    public bool PlayerGrabInput { get; private set; }
    public bool PlayerDashInput { get; private set; }
    public bool PlayerDashInputStop { get; private set; }

    [SerializeField] private float _playerInputHoldTime = 0.2f;

    private float _playerJumpInputStartTime;
    private float _playerDashInputStartTime;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _camera = Camera.main;
    }

    private void Update()
    {
        CheckPlayerJumpInputHoldTime();
        CheckPlayerDashInputHoldTime();
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

    public void OnPlayerDashInput(InputAction.CallbackContext button)
    {
        if (button.started)
        {
            PlayerDashInput = true;
            PlayerDashInputStop = false;
            _playerDashInputStartTime = Time.time;
        }
        else if (button.canceled)
        {
            PlayerDashInputStop = true;
        }
    }

    public void OnPlayerDashInputDirection(InputAction.CallbackContext direction)
    {
        RawPlayerDashDirectionInput = direction.ReadValue<Vector2>();

        if (_playerInput.currentControlScheme == "Keyboard")
        {
            RawPlayerDashDirectionInput = _camera.ScreenToWorldPoint((Vector3)RawPlayerDashDirectionInput) - transform.position;
        }

        PlayerDashDirectionInput = Vector2Int.RoundToInt(RawPlayerDashDirectionInput.normalized);
    }

    public void PlayerUsedJumpInput() => PlayerJumpInput = false;

    public void PlayerUsedDashInput() => PlayerDashInput = false;

    private void CheckPlayerJumpInputHoldTime()
    {
        if (Time.time >= _playerJumpInputStartTime + _playerInputHoldTime)
        {
            PlayerJumpInput = false;
        }
    }

    private void CheckPlayerDashInputHoldTime()
    {
        if (Time.time >= _playerDashInputStartTime + _playerInputHoldTime)
        {
            PlayerDashInput = false;
        }
    }
}    
