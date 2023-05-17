using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public bool pauseMenuUp;
    public bool levelScreenClear;
    public bool canPress;

    private PlayerInput _playerInput;
    private Camera _camera;
    
    public Vector2 RawPlayerMovementInput { get; private set; }
    
    public Vector2 RawPlayerDashDirectionInput { get; private set; }
    
    public Vector2 RawPlayerGrappleHookDirectionInput { get; private set; }
    public Vector2Int PlayerDashDirectionInput { get; private set; }
    
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool PlayerJumpInput { get; private set; }
    public bool PlayerJumpInputStop { get; private set; }
    public bool PlayerGrabInput { get; private set; }
    public bool PlayerDashInput { get; private set; }
    public bool PlayerDashInputStop { get; private set; }
    public bool PlayerGrappleHookInput { get; private set; }
    public bool PauseMenuInput { get; set; }

    public bool InteractInput {get; set; }

    public bool[] PlayerAttackInputs { get; private set; }

    [SerializeField] private float _playerInputHoldTime = 0.2f;

    private float _playerJumpInputStartTime;
    private float _playerDashInputStartTime;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(PlayerCombatInputs)).Length;
        PlayerAttackInputs = new bool[count];
        
        _camera = Camera.main;

        pauseMenuUp = false;
        canPress = false;

        Time.timeScale = 1;
    }

    private void Update()
    {
        CheckPlayerJumpInputHoldTime();
        CheckPlayerDashInputHoldTime();
    }

    public void OnPlayerPrimaryAttackInput(InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false)
        {
            if (button.started)
            {
                PlayerAttackInputs[(int)PlayerCombatInputs.primary] = true;
            }

            if (button.canceled)
            {
                PlayerAttackInputs[(int)PlayerCombatInputs.primary] = false;
            }
        }
        
    }

    public void OnPlayerSecondaryAttackInput(InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false)
        {
            if (button.started)
            {
                PlayerAttackInputs[(int)PlayerCombatInputs.secondary] = true;
            }

            if (button.canceled)
            {
                PlayerAttackInputs[(int)PlayerCombatInputs.secondary] = false;
            }
        }
        
    }

    public void OnMovementInput(InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false)
        {
            RawPlayerMovementInput = button.ReadValue<Vector2>();

            NormInputX = Mathf.RoundToInt(RawPlayerMovementInput.x);
            NormInputY = Mathf.RoundToInt(RawPlayerMovementInput.y);
        }
        

    }

    public void OnJumpInput(InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false)
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
        
    }

    public void OnPlayerGrabInput( InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false)
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
        
    }

    public void OnPlayerDashInput(InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false)
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
        
    }

    public void OnPlayerGrappleHookInput(InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false)
        {
            if (button.started)
            {
                PlayerGrappleHookInput = true;

            }
            else if (button.canceled)
            {
                PlayerGrappleHookInput = false;
            }
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

    public void PlayerUsedGrappleHookInput() => PlayerGrappleHookInput = false;

    public void PlayerUsedWallGrabInput() => PlayerGrabInput = false;

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

    public void OnPauseMenuInput(InputAction.CallbackContext button)
    {
        if (levelScreenClear == false)
        {
            if (button.started)
            {
                PauseMenuInput = true;
            }
            else if (button.canceled)
            {
                PauseMenuInput = false;
            }
        }

    }

    public void OnInteractInput(InputAction.CallbackContext button)
    {
        if (pauseMenuUp == false && levelScreenClear == false && canPress == true)
        {
            if (button.started)
            {
                InteractInput = true;

            }
            else if (button.canceled)
            {
                InteractInput = false;
            }
        }
    }
}

public enum PlayerCombatInputs
{
    primary,
    secondary
}
