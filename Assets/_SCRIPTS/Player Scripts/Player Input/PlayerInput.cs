using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 RawPlayerMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    
    public void OnMovementInput(InputAction.CallbackContext button)
    {
        RawPlayerMovementInput = button.ReadValue<Vector2>();

        NormInputX = (int)(RawPlayerMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawPlayerMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext button)
    {
        
    }
}
