using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected Transform mainPlayer;

    protected MainCharacterController stateMachine;

    protected GameObject MenuPlane;

    public void Initialize(Transform transform,MainCharacterController mainCharacterController,GameObject menuPanel)
    {
        this.mainPlayer = transform;
        this.stateMachine = mainCharacterController;
        this.MenuPlane = menuPanel;
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
