using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/WaitEnemy", fileName = "PlayerState_WaitEnemy")]
public class WaiteEnemy : PlayerState
{
    public override void Enter()
    {
        //EnemyObjectController.Instance.EnemyMove();
    }
    public override void LogicUpdate()
    {
        
        if (!mainPlayer.GetComponent<EnemyObjectController>().isDoing)
            stateMachine.SwitchState(typeof(WaitMoveState));
    }
}
   

