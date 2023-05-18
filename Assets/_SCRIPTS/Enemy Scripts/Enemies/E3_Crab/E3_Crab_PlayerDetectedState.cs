using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Crab_PlayerDetectedState : Enemy_PlayerDetectedState
{
    private float distance;

    public E3_Crab_PlayerDetectedState(EnemyBase _enemyBase, EnemyFiniteStateMachine _enemyStateMachine, string _enemyAnimationBoolName, D_EnemyData _enemyData, E3_Crab enemyCrab) : base(_enemyBase, _enemyStateMachine, _enemyAnimationBoolName, _enemyData)
    {
        _enemyCrab = enemyCrab;
    }

    protected MovementComponent MovementComponent
    {
        get => _movementComponent ??= _core.GetCoreComponent<MovementComponent>();
    }
    private MovementComponent _movementComponent;

    private E3_Crab _enemyCrab;
    

    public override void StateEnter()
    {
        base.StateEnter();
        Debug.Log("PlayerDetectedState");
    }

    public override void StateExit()
    {
        base.StateExit();
    }

    public override void EveryFrameUpdate()
    {
        base.EveryFrameUpdate();

        distance = Vector2.Distance(_enemyCrab.transform.position, _enemyCrab.player.transform.position);

        if (distance <= 10)
        {
            _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_AttackState);
        }
        else if (distance >= 10)
        {
            _enemyStateMachine.ChangeEnemyState(_enemyCrab.crab_LookForPlayerState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
