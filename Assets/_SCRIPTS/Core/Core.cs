using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public MovementComponent MovementComponent
    {
        get
        {
            if (_movementComponent != null)
            {
                return _movementComponent;
            }
            Debug.LogError("No Movement Core Component on" + transform.parent.name);
            return null;
        }

        private set
        {
            _movementComponent = value;
        }
    }

    public CollisionSenses CollisionSenses
    {
        get
        {
            if (_collisionSenses != null)
            {
                return _collisionSenses;
            }
            Debug.LogError("No Collision Senses Core Component on" + transform.parent.name);
            return null;
        }

        private set
        {
            _collisionSenses = value;
        }
    }

    private MovementComponent _movementComponent;
    private CollisionSenses _collisionSenses;

    private void Awake()
    {
        MovementComponent = GetComponentInChildren<MovementComponent>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();

        
    }

    public void EveryFrameUpdate()
    {
        MovementComponent.EveryFrameUpdate();
    }
}
