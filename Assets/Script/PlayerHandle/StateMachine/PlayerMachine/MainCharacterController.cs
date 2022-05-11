using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : StateMachine
{
    [SerializeField] PlayerState[] states;

    [SerializeField] GameObject menuPanel;

    public Vector3 movePosition;
    private void Awake()
    {
        stateTable = new Dictionary<System.Type, IState>(states.Length);
        foreach(PlayerState state in states)
        {
            state.Initialize(this.gameObject.transform,this,menuPanel);
            stateTable.Add(state.GetType(), state);
        }
        
    }
    private void Start()
    {
        SwitchOn(stateTable[typeof(WaitMoveState)]);
    }

}
