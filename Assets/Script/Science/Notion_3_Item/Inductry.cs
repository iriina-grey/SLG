using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Science/Item/ScienceItem/Inductry", fileName = "Inductry_")]
public class Inductry : ScienceItem
{
    public float up_factoryProduce;
    public float pup_factoryProduce;
    public float down_factory_Energy;
    public float down_factory_Mimeral;
    public float down_BuildSpend;
    int down_BuildRound;
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
                gameData.Up_factoryProduce+=up_factoryProduce;
                break;
            case 2:
                gameData.Pup_factoryProduce+=pup_factoryProduce ;
                break;
            case 3:
                gameData.Down_factory_Energy+=down_factory_Energy;
                break;
            case 4:
                gameData.Down_factory_Mimeral+=down_factory_Mimeral;
                break;
            case 5:
                gameData.Down_BuildRound += down_BuildRound;
                break;
            default:
                gameData.Down_BuildSpend+=down_BuildSpend;

                break;
        }
    }
}
