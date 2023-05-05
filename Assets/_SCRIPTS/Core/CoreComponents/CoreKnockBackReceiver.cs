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
        coreMovement?.SetEntityVelocity(strength, angle, direction);
        coreMovement.CanSetEntityVelocity = false;
        _isEntityKnockBackActive = true;
        _knockbackStartTime = Time.time;
    }

    private void CheckEntityKnockBack()
    {
        if (_isEntityKnockBackActive && ((coreMovement?.EntityCurrentVelocity.y <= 0.01f && coreCollisionSenses.CheckIfEntityGrounded) || Time.time >= _knockbackStartTime + _maxKnockBackTime))
        {
            _isEntityKnockBackActive = false;
            coreMovement.CanSetEntityVelocity = true;
        }
    }
}
