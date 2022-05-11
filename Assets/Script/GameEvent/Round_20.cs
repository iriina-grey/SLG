using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Round_20", menuName = "Data/GameEvent/Round_20")]
public class Round_20 : GameEventItem
{
    public override void Event()
    {
        base.Event();
        PlayerIns.Instance.moveRangeNum += 1;
        PlayerIns.Instance.MoveAreaIns();
    }
}
