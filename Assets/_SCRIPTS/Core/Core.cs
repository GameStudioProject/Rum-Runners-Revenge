using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public MovementComponent MovementComponent
    {
        get => GenericCoreNotImplementedError<MovementComponent>.TryGet(_movementComponent, transform.parent.name);
        private set => _movementComponent = value;
    }

    public CollisionSenses CollisionSenses
    {
        get => GenericCoreNotImplementedError<CollisionSenses>.TryGet(_collisionSenses, transform.parent.name);
        private set => _collisionSenses = value;
    }

    public CombatComponent CombatComponent
    {
        get => GenericCoreNotImplementedError<CombatComponent>.TryGet(_combatComponent, transform.parent.name);
        private set => _combatComponent = value;
    }

    private MovementComponent _movementComponent;
    private CollisionSenses _collisionSenses;
    private CombatComponent _combatComponent;

    private void Awake()
    {
        MovementComponent = GetComponentInChildren<MovementComponent>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        CombatComponent = GetComponentInChildren<CombatComponent>();
    }

    public void EveryFrameUpdate()
    {
        MovementComponent.EveryFrameUpdate();
        CombatComponent.LogicUpdate();
    }
}
