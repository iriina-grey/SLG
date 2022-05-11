using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Science/Item/ScienceItem/ShengWu", fileName = "ShengWu_")]
public class ShengWu : ScienceItem
{
    public float farmProduce;
    public float framSpend_Energy;
    public float up_farmProduce;
    public float pup_farmProduce;
    public float down_framSpend_Energy;
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
                gameData.FarmProduce += farmProduce;
                break;
            case 2:
                gameData.FramSpend_Energy += farmProduce;
                break;
            case 3:
                gameData.Up_farmProduce += up_farmProduce;
                break;
            case 4:
                gameData.Pup_farmProduce += pup_farmProduce;
                break;
            default:
                gameData.Down_framSpend_Energy += down_framSpend_Energy;
                break;
        }
    }

}
