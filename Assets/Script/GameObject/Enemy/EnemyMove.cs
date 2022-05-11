using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Moving", fileName = "EnemyState_Moving")]
public class EnemyMove : EnemyState
{
    Vector3 move_Horizontal = new Vector3(100f, 0f, 0f);
    Vector3 move_Vertical = new Vector3(0f, 0f, 100f);
    Vector3 movePosition;
    float speed;
    public override void Enter()
    {
        mainPlayer.transform.GetComponent<EnemyObjectController>().isNext = false;
        movePosition = GetMovePosition(2);
        Debug.Log("position" + movePosition);
        speed = 2f;


    }
    public override void LogicUpdate()
    {
        if (self.position != movePosition)
        {
            self.Translate((movePosition - self.position) * speed * Time.deltaTime);
            if (Mathf.Abs((movePosition - self.position).magnitude) <= 0.5)
                self.position = movePosition;
        }
        else
        {
            //stateMachine.SwitchState(typeof(WaitMoveState));
            Debug.Log("Switch");
            
        }
    }
    
    Vector3 GetMovePosition(int level)
    {
        Vector3 playerPosition=mainPlayer.position;
        Vector3 selfPosition=self.position;
        Vector3 offer = playerPosition-selfPosition;
        Vector3 offer_=new Vector3();
        for (int i = 0;i< level; i++)
        {
            if(Mathf.Abs(offer.x)> Mathf.Abs(offer.z))
            {
            if (offer.x > 0)
                {
                offer_ += move_Horizontal;
                }
                else
                {
                    offer_ -= move_Horizontal;
                }
            }
            else
            {
                if (offer.z > 0)
                {
                    offer_ += move_Vertical;
                }
                else
                {
                    offer_ -= move_Vertical;
                }
            }
        }
        return offer_+selfPosition;
    }
        
    
}
