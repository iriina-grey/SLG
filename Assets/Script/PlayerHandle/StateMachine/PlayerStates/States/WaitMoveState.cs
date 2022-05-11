using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/WaitMove", fileName = "PlayerState_WaitMove")]
public class WaitMoveState : PlayerState
{
    LayerMask LayerMask = 1 << 9;
    public override void Enter()
    {
        mainPlayer.Find("MoveArea").gameObject.SetActive(true);
    }
    public override void LogicUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(ray, out hit,Mathf.Infinity,LayerMask))
                {
                    stateMachine.movePosition = hit.transform.position +new Vector3(0, 50f, 0);
                    stateMachine.SwitchState(typeof(MovingState));
                }                                              
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPlane.SetActive(true);
        }
        
    }
    public override void Exit()
    {
        base.Exit();
        MenuPlane.SetActive(false);
    }
}
