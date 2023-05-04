using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CoreKnockBackReceiver : CoreComponent, KnockBackInterface
{
    [SerializeField] private float _maxKnockBackTime = 0.2f;
    
    private bool _isEntityKnockBackActive;
    private float _knockbackStartTime;
    
    public override void LogicUpdate()
    {
        CheckEntityKnockBack();
    }

    public void KnockBack(Vector2 angle, float strength, int direction)
    {
        movementComponent.Component?.SetEntityVelocity(strength, angle, direction);
        movementComponent.Component.CanSetEntityVelocity = false;
        _isEntityKnockBackActive = true;
        _knockbackStartTime = Time.time;
    }

    private void CheckEntityKnockBack()
    {
        if (_isEntityKnockBackActive && ((movementComponent.Component?.EntityCurrentVelocity.y <= 0.01f && collisionSenses.Component.CheckIfEntityGrounded) || Time.time >= _knockbackStartTime + _maxKnockBackTime))
        {
            _isEntityKnockBackActive = false;
            movementComponent.Component.CanSetEntityVelocity = true;
        }
    }
}
