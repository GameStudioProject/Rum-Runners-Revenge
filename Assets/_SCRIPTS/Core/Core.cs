using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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

    public StatsComponent StatsComponent
    {
        get => GenericCoreNotImplementedError<StatsComponent>.TryGet(_statsComponent, transform.parent.name);
        private set => _statsComponent = value;
    }

    private MovementComponent _movementComponent;
    private CollisionSenses _collisionSenses;
    private CombatComponent _combatComponent;
    private StatsComponent _statsComponent;

    private List<LogicUpdateInterface> _componentsList = new List<LogicUpdateInterface>();

    private void Awake()
    {
        MovementComponent = GetComponentInChildren<MovementComponent>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        CombatComponent = GetComponentInChildren<CombatComponent>();
        StatsComponent = GetComponentInChildren<StatsComponent>();
    }

    public void EveryFrameUpdate()
    {
        foreach (LogicUpdateInterface _componentList in _componentsList)
        {
            _componentList.LogicUpdate();
        }
    }

    public void AddCoreComponent(LogicUpdateInterface coreComponent)
    {
        if (!_componentsList.Contains(coreComponent))
        {
            _componentsList.Add(coreComponent);
        }
    }
}
