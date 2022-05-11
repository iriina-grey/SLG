using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Moving",fileName ="PlayerState_Moving")]
public class MovingState : PlayerState
{

    float speed;
    public override void Enter()
    {
        speed = 2f;
        mainPlayer.Find("ShipModle"). LookAt(stateMachine.movePosition);
        mainPlayer.Find("MoveArea").gameObject.SetActive(false);
        
    }
    public override void LogicUpdate()
    {
        if (mainPlayer.position != stateMachine.movePosition)
        {
            mainPlayer.Translate((stateMachine.movePosition - mainPlayer.position) * speed * Time.deltaTime);
            if (Mathf.Abs((stateMachine.movePosition - mainPlayer.position).magnitude) <= 0.5)
                mainPlayer.position = stateMachine.movePosition;
        }
        else
        {
            stateMachine.SwitchState(typeof(WaiteEnemy));
        }
    }
    public override void Exit()
    {
        EventController.Instance.DoEvent();
        mainPlayer.GetComponent<EnemyObjectController>().EnemyRoundStart();
        

    }
}
