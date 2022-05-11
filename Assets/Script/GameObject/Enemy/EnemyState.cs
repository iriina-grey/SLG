using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : ScriptableObject, IState
{
    protected Transform mainPlayer;
    protected Transform self;
    protected Enemy stateMachine;

    public void Initialize(Transform transform_p,Enemy mainCharacterController,Transform transform_self)
    {
        this.mainPlayer = transform_p;
        this.stateMachine = mainCharacterController;
        this.self = transform_self;
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {

    }
}
