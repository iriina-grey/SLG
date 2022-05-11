using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Science/Item/ScienceItem/Social", fileName = "Social_")]
public class Social : ScienceItem
{
    public float man_Reduce_Farm;
    public float man_Reduce_Produce;
    public float man_Increace_SciencePoint;


    public int type;
    public override void DoEvent()
    {
        base.DoEvent();
        ValueChange(type);
    }
    void ValueChange(int type)
    {
        GameDataValue gameData = GameObject.Find("ValueOfGame").GetComponent<GameDataValue>();
        switch (type)
        {
            case 1:
                gameData.man_Reduce_Farm += man_Reduce_Farm;
                break;
            case 2:
                gameData.man_Reduce_Produce += man_Reduce_Farm;
                break;
           
            default:
                gameData.man_Increace_SciencePoint += man_Increace_SciencePoint;
                break;
        }
    }

}
