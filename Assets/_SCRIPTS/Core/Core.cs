using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public MovementComponent MovementComponent { get; private set; }
    public CollisionSenses CollisionSenses { get; private set; }

    private void Awake()
    {
        MovementComponent = GetComponentInChildren<MovementComponent>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();

        if (!MovementComponent || !CollisionSenses)
        {
            Debug.LogError("Missing Core Component");
        }
    }

    public void EveryFrameUpdate()
    {
        MovementComponent.EveryFrameUpdate();
    }
}
